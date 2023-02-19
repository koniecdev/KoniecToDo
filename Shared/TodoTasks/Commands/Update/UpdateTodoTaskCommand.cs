namespace Shared.TodoTasks.Commands;
public class UpdateTodoTaskCommand : IRequest<Unit>, IMapFrom<TodoTask>
{
	public UpdateTodoTaskCommand()
	{
	}
	public int Id { get; set; }
	public string? Title { get; set; }
	public DateTime? Deadline { get; set; }
	public int? PriorityId { get; set; }
	public int? TodoListId { get; set; }
	public bool? Completed { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateTodoTaskCommand, TodoTask>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
