namespace Shared.TodoLists.Queries.GetAll;
public class GetTodoListsDto : IMapFrom<TodoList>
{
	public GetTodoListsDto()
	{
		Name = string.Empty;
	}
	public int Id { get; set; }
	public string Name { get; set; }
	public ICollection<GetTodoListsTodoTaskDto>? TodoTasks { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<TodoList, GetTodoListsDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
