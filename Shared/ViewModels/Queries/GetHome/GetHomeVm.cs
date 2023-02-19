namespace Shared.ViewModels.Queries.GetHome;
public class GetHomeVm
{
	public GetHomeVm()
	{
		TodoLists = new List<GetHomeTodoListDto>();
		TodoTasks = new List<GetHomeTodoTaskDto>();
	}
	public int? SelectedTodoListId { get; set; }
	public ICollection<GetHomeTodoListDto>? TodoLists { get; set; }
	public ICollection<GetHomeTodoTaskDto>? TodoTasks { get; set; }
}
