namespace Shared.ViewModels.Queries.GetHome;
public class GetHomeTodoListDto : IMapFrom<TodoList>
{
	public GetHomeTodoListDto()
	{
		Name = string.Empty;
	}
	public string Name { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<TodoList, GetHomeTodoListDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
		profile.CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
		profile.CreateMap<DateTime?, DateTime>().ConvertUsing((src, dest) => src ?? dest);
	}
}
