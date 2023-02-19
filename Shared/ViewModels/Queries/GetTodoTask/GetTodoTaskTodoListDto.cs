namespace Shared.ViewModels.Queries.GetTodoTask;

public class GetTodoTaskTodoListDto : IMapFrom<TodoList>
{
	public GetTodoTaskTodoListDto()
	{
		Name = string.Empty;
	}
	public int Id { get; set; }
	public string Name { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<TodoList, GetTodoTaskTodoListDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
