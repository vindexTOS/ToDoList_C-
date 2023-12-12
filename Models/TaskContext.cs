using Microsoft.EntityFrameworkCore;
using todoc.Models;
namespace todoc.Cotnext;

public class TaskDbContext :DbContext 
{
	 public TaskDbContext(DbContextOptions<TaskDbContext> options) : base (options)  { }
     public DbSet< ToDoItem> ToDoItems { get; set; }

   
}