namespace Shared.Priorities.Queries.GetAll;
public class GetPrioritiesDto : IMapFrom<Priority>
{
	public GetPrioritiesDto()
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
		profile.CreateMap<Priority, GetPrioritiesDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
