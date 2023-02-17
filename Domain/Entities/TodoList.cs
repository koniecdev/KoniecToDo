using Domain.Common;
namespace Domain.Entities;
public class TodoList : AuditableEntity
{
	public TodoList()
	{
		Name = string.Empty;
	}
	public TodoList(string name)
	{
		Name = name;
	}
	public string Name { get; set; }
	public virtual ICollection<TodoTask>? TodoTasks { get; set; }
}
