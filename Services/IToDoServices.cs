using ToDoApi.DTO;
using todoc.Models;

namespace ToDoApi.controller;

public interface IToDoService
{
	Task<List<ToDoItem>> Get();
	Task<ToDoItem> PostToDoItem(ToDoItemDTO itemDTO);
	Task<ToDoItem> GetSingleToDo(int id);

	Task<ToDoItem> PutToDoItem(ToDoItem updatedItem);
	Task DeleteToDoItem(int id);
}