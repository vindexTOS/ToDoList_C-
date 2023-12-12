using Microsoft.AspNetCore.Mvc;
using ToDoApi.DTO;
using todoc.Cotnext;
using todoc.Models;

namespace ToDoApp.Api.Controller;

[ApiController]
[Route("api/[controller]")]

public class ToDoController : ControllerBase

{
	private readonly TaskDbContext _context;
	
	
	public ToDoController(TaskDbContext context)
	{
		_context = context;
	}

		[HttpGet]
		public ActionResult<IEnumerable<ToDoItem>> Get()
		{
		return Ok(_context.ToDoItems.ToList());
		}
		[HttpPost]
		public ActionResult<ToDoItem> Post([FromBody] ToDoItemDTO itemDTO)
		{
		var item = new ToDoItem  {
			Title = itemDTO.Title,
		};
		

		_context.ToDoItems.Add(item);
		_context.SaveChanges();
				itemDTO.ID = item .ID;

		return CreatedAtAction(nameof(Get), new { id = itemDTO.ID }, itemDTO);
	}

		[HttpGet("{id}")]
		public ActionResult<ToDoItem>GetOne(int id)
		{
		var singleItem = _context.ToDoItems.Find(id);
		
			if(singleItem is null)
			{
			return NotFound();
			}

		return Ok(singleItem);
		}

		[HttpPut]
		public ActionResult<ToDoItem>Put([FromBody] ToDoItem updatedItem)
		{
			int id = updatedItem.ID;
		var isItemExist = _context.ToDoItems.Find(id);
			if(isItemExist is null)
			{
			return NotFound();
			}

		isItemExist.Title = updatedItem.Title;
		isItemExist.IsActive = updatedItem.IsActive;

		_context.SaveChanges();

		return GetOne(id);
	}
}