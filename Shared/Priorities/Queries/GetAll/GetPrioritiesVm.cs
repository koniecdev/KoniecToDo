namespace Shared.Priorities.Queries.GetAll;
public class GetPrioritiesVm
{
	public GetPrioritiesVm()
	{
		Priorities = new List<GetPrioritiesDto>();
	}
	public GetPrioritiesVm(ICollection<GetPrioritiesDto> priorities)
	{
		Priorities = priorities;
	}

	public ICollection<GetPrioritiesDto> Priorities { get; set; }
}
