namespace Shared.Priorities.Commands;
public class UpdatePriorityCommand : IRequest<Unit>, IMapFrom<Priority>
{
	public UpdatePriorityCommand()
	{
	}
	public int Id { get; set; }
	public int? Level { get; set; }
	public string? Color { get; set; }
	public string? Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdatePriorityCommand, Priority>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
