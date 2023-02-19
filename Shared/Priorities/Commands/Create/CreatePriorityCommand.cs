namespace Shared.Priorities.Commands;
public class CreatePriorityCommand : IRequest<int>, IMapFrom<Priority>
{
	public CreatePriorityCommand()
	{
		Color = string.Empty;
		Name = string.Empty;
	}

	public int Level { get; set; }
	public string Color { get; set; }
	public string Name { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreatePriorityCommand, Priority>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
