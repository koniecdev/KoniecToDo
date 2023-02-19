namespace Shared.ViewModels.Queries.GetTodoList;
public class GetTodoListDto : IMapFrom<TodoList>
{
	public GetTodoListDto()
	{
		Name = string.Empty;
	}

	public string Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<TodoList, GetTodoListDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
