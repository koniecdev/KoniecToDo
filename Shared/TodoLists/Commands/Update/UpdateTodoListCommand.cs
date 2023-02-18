namespace Shared.TodoLists.Commands;
public class UpdateTodoListCommand : IRequest<Unit>, IMapFrom<TodoList>
{
	public UpdateTodoListCommand()
	{
	}
	public int Id { get; set; }
	public string? Name { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateTodoListCommand, TodoList>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
