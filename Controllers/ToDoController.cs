using Microsoft.AspNetCore.Mvc;
using ToDoApi.controller;
using ToDoApi.DTO;
using todoc.Cotnext;
using todoc.Models;
using todoc.Services;

namespace ToDoApp.Api.Controller;

[ApiController]
[Route("api/[controller]")]

public class ToDoController : ControllerBase

{
	private readonly TaskDbContext _context;
	private readonly IToDoService _Service;

	public ToDoController(TaskDbContext context, IToDoService service)
	{
		_context = context;
		_Service = service;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		try
		{
			var result = await _Service.Get();
			return Ok(result);
		}
		catch (InvalidDataException ex)
		{
			return StatusCode(500, ex.Message);
		}
	}
	[HttpPost]
	public async Task<IActionResult> Post([FromBody] ToDoItemDTO itemDTO)
	{
		try
		{
			var createdItem = await _Service.PostToDoItem(itemDTO);
			return CreatedAtAction(nameof(Get), new { id = createdItem.ID }, createdItem);
		}
		catch (InvalidOperationException ex)
		{
			return NotFound(new { message = ex.Message });
		}
		catch (InvalidDataException ex)
		{
			return StatusCode(500, new { message = ex.Message });
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetOne(int id)
	{
		try
		{
			var result = await _Service.GetSingleToDo(id);
			return Ok(result);
		}
		catch (InvalidOperationException ex)
		{
			return NotFound(new { message = ex.Message });

		}
		catch (InvalidDataException ex)
		{

			return StatusCode(500, new { message = ex.Message });

		}

	}

	[HttpPut]
	public async Task<IActionResult> Put([FromBody] ToDoItem updatedItem)
	{
		try
		{
			var result = await _Service.PutToDoItem(updatedItem);
			return Ok(result);
		}
		catch (InvalidOperationException ex)
		{

			return NotFound(new { message = ex.Message });

		}
		catch (InvalidDataException ex)
		{
			return StatusCode(500, new { message = ex.Message });
		}
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{
			await _Service.DeleteToDoItem(id);
			return Ok();
		}
		catch (InvalidOperationException ex)
		{
			return NotFound(new { message = ex.Message });
		}
		catch (InvalidDataException ex)
		{
			return StatusCode(500, ex.Message);
		}
	}
}

