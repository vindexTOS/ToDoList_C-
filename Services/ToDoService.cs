
using Microsoft.EntityFrameworkCore;
using ToDoApi.controller;
using ToDoApi.DTO;
using todoc.Cotnext;
using todoc.Models;

namespace todoc.Services;



public class ToDoService : IToDoService
{
	private readonly TaskDbContext _context;

	public ToDoService(TaskDbContext context)
	{
		_context = context;
	}
	public async Task<List<ToDoItem>> Get()
	{
		return await _context.ToDoItems.ToListAsync();
	}

	public async Task<ToDoItem> PostToDoItem(ToDoItemDTO itemDTO)
	{
		var item = new ToDoItem
		{
			Title = itemDTO.Title,
		};

		await _context.ToDoItems.AddAsync(item);
		await _context.SaveChangesAsync();

		itemDTO.ID = item.ID;

		return item;
	}


	public async Task<ToDoItem> GetSingleToDo(int id)
	{
		var result = await _context.ToDoItems.FindAsync(id) ?? throw new InvalidOperationException("Item not found");
        return result;
	}

	public async Task<ToDoItem> PutToDoItem(ToDoItem updatedItem)
	{
		int id = updatedItem.ID;
		var isItemExist = await _context.ToDoItems.FindAsync(id) ?? throw new InvalidOperationException("Item not found");
        isItemExist.Title = updatedItem.Title;
		isItemExist.IsActive = updatedItem.IsActive;

		await _context.SaveChangesAsync();
		var result = await GetSingleToDo(id);
		return result;
	}

	public async Task DeleteToDoItem(int id)
	{
		var result = _context.ToDoItems.FirstOrDefault(x => x.ID == id) ?? throw new InvalidOperationException("Item not found");
        _context.Remove(result);
		await _context.SaveChangesAsync();
	}


}


