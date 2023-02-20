namespace Shared.ViewModels.Queries.GetHome;
public class GetHomeTodoTaskTodoListDto : IMapFrom<TodoList>
{
	public GetHomeTodoTaskTodoListDto()
	{
		Name = string.Empty;
	}
	public string Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<TodoList, GetHomeTodoTaskTodoListDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
