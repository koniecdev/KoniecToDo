using Domain.Common;
namespace Domain.Entities;
public class TodoTask : AuditableEntity
{
	public TodoTask()
	{
		Title = string.Empty;
	}
	public TodoTask(string title, string description, DateTime deadline, int priorityId)
	{
		Title = title;
		Description = description;
		Deadline = deadline;
		PriorityId = priorityId;
	}

	public string Title { get; set; }
	public string? Description { get; set; }
	public DateTime Deadline { get; set; }
	public int PriorityId { get; set; }
	public virtual Priority? Priority { get; set; }
}
