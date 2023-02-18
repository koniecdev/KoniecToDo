namespace Shared.TodoLists.Queries.GetAll;
public class GetTodoListsVm
{
	public GetTodoListsVm()
	{
		TodoLists = new List<GetTodoListsDto>();
	}
	public GetTodoListsVm(ICollection<GetTodoListsDto> todoLists)
	{
		TodoLists = todoLists;
	}

	public ICollection<GetTodoListsDto> TodoLists { get; set; }
}
