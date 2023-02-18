using Domain.Common;
namespace Domain.Entities;
public class TodoTask : AuditableEntity
{
	public TodoTask()
	{
		Title = string.Empty;
		Completed = false;
	}
	public TodoTask(string title, DateTime deadline, int priorityId)
	{
		Title = title;
		Deadline = deadline;
		PriorityId = priorityId;
		Completed = false;
	}

	public string Title { get; set; }
	public DateTime Deadline { get; set; }
	public bool Completed { get; set; }
	public int PriorityId { get; set; }
	public virtual Priority? Priority { get; set; }
	public int TodoListId { get; set; }
	public virtual TodoList? TodoList { get; set; }
}
