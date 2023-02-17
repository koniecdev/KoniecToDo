using Domain.Common;
namespace Domain.Entities;
public class Priority : AuditableEntity
{
	public Priority()
	{
		Color = string.Empty;
	}
	public Priority(int level, string color)
	{
		Level = level;
		Color = color;
	}
	public int Level { get; set; }
	public string Color { get; set; }
	public virtual ICollection<TodoTask>? TodoTasks { get; set; }
}
