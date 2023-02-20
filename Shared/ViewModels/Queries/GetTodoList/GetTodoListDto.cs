using Shared.TodoLists.Commands;

namespace Shared.ViewModels.Queries.GetTodoList;
public class GetTodoListDto : IMapFrom<TodoList>
{
	public GetTodoListDto()
	{
		Name = string.Empty;
	}

	public int? Id { get; set; }
	public string? Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<TodoList, GetTodoListDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
		profile.CreateMap<GetTodoListDto, CreateTodoListCommand>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
		profile.CreateMap<GetTodoListDto, UpdateTodoListCommand>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
