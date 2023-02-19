namespace Shared.ViewModels.Queries.GetTodoTask;

public class GetTodoTaskVm
{
	public GetTodoTaskVm()
	{
		TodoLists = new List<GetTodoTaskTodoListDto>();
		Priorities = new List<GetTodoTaskPriorityDto>();
		TodoTask = new();
	}
	public ICollection<GetTodoTaskTodoListDto>? TodoLists { get; set; }
	public ICollection<GetTodoTaskPriorityDto>? Priorities { get; set; }
	public GetTodoTaskDto TodoTask { get; set; }
}
