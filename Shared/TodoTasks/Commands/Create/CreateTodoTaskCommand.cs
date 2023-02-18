namespace Shared.TodoTasks.Commands;
public class CreateTodoTaskCommand : IRequest<int>, IMapFrom<TodoTask>
{
	public CreateTodoTaskCommand()
	{
		Title = string.Empty;
	}

	public string Title { get; set; }
	public DateTime Deadline { get; set; }
	public int PriorityId { get; set; }
	public int TodoListId { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateTodoTaskCommand, TodoTask>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
