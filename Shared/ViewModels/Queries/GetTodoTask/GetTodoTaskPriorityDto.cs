namespace Shared.ViewModels.Queries.GetTodoTask;

public class GetTodoTaskPriorityDto : IMapFrom<Priority>
{
	public GetTodoTaskPriorityDto()
	{
		Color = string.Empty;
		Name = string.Empty;
	}

	public int Id { get; set; }
	public int Level { get; set; }
	public string Color { get; set; }
	public string Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Priority, GetTodoTaskPriorityDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
