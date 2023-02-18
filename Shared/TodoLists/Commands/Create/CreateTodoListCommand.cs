namespace Shared.TodoLists.Commands;
public class CreateTodoListCommand : IRequest<int>, IMapFrom<TodoList>
{
	public CreateTodoListCommand()
	{
		Name = string.Empty;
	}

	public string Name { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateTodoListCommand, TodoList>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
