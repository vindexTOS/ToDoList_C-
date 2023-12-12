using System.ComponentModel.DataAnnotations;

namespace ToDoApi.DTO;
public class ToDoItemDTO
{
	public int ID { get; set; }
	[Required]
	
	public string? Title { get; set; }
	
	public bool IsActive { get; set; } = false;
 
}