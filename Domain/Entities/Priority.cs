using Domain.Common;
namespace Domain.Entities;
public class Priority : AuditableEntity
{
	public Priority()
	{
		Color = string.Empty;
		Name = string.Empty;
	}
	public Priority(int level, string color, string name)
	{
		Level = level;
		Color = color;
		Name = name;
	}
	public int Level { get; set; }
	public string Color { get; set; }
	public string Name { get; set; }
	public virtual ICollection<TodoTask>? TodoTasks { get; set; }
}
