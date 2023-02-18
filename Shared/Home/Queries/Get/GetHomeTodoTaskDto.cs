namespace Shared.Home.Queries.Get;
public class GetHomeTodoTaskDto : IMapFrom<TodoTask>
{
	public GetHomeTodoTaskDto()
	{
		Title = string.Empty;
		Priority = new();
	}

	public string Title { get; set; }
	public DateTime Deadline { get; set; }
	public bool Completed { get; set; }
	public int PriorityId { get; set; }
	public GetHomeTodoTaskPriorityDto Priority { get; set; }
	public int TodoListId { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<TodoTask, GetHomeTodoTaskDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
