namespace Shared.TodoTasks.Queries.GetAll;
public class GetTodoTasksVm
{
	public GetTodoTasksVm()
	{
		TodoTasks = new List<GetTodoTasksDto>();
	}
	public GetTodoTasksVm(ICollection<GetTodoTasksDto> todoTasks)
	{
		TodoTasks = todoTasks;
	}

	public ICollection<GetTodoTasksDto> TodoTasks { get; set; }
}
