namespace Shared.TodoLists.Queries.GetAll;
public class GetTodoListsTodoTaskDto : IMapFrom<TodoTask>
{
	public GetTodoListsTodoTaskDto()
	{
		Title = string.Empty;
	}
	public int Id { get; set; }
	public string Title { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<TodoTask, GetTodoListsTodoTaskDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
