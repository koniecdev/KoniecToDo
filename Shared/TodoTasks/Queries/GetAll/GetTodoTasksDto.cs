namespace Shared.TodoTasks.Queries.GetAll;
public class GetTodoTasksDto : IMapFrom<TodoTask>
{
	public GetTodoTasksDto()
	{
		Title = string.Empty;
	}
	public int Id { get; set; }
	public string Title { get; set; }
	public DateTime Deadline { get; set; }
	public int PriorityId { get; set; }
	public int TodoListId { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<TodoTask, GetTodoTasksDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
