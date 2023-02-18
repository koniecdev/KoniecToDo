namespace Shared.Home.Queries.Get;
public class GetHomeVm
{
	public GetHomeVm()
	{
		TodoLists = new List<GetHomeTodoListDto>();
		TodoTasks = new List<GetHomeTodoTaskDto>();
	}
	public ICollection<GetHomeTodoListDto>? TodoLists { get; set; }
	public ICollection<GetHomeTodoTaskDto>? TodoTasks { get; set; }
}
