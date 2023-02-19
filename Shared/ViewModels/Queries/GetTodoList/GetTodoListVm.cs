namespace Shared.ViewModels.Queries.GetTodoList;
public class GetTodoListVm
{
	public GetTodoListVm()
	{
		TodoList = new();
	}
	public GetTodoListDto TodoList { get; set; }
}
