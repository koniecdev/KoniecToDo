namespace Shared.ViewModels.Queries.GetHome;
public class GetHomeTodoTaskPriorityDto : IMapFrom<Priority>
{
	public GetHomeTodoTaskPriorityDto()
	{
		Color = string.Empty;
	}

	public int Level { get; set; }
	public string Color { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Priority, GetHomeTodoTaskPriorityDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
