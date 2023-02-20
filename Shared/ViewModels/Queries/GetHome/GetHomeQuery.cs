namespace Shared.ViewModels.Queries.GetHome;
public class GetHomeQuery : IRequest<GetHomeVm>
{
	public GetHomeQuery()
	{
	}
	public GetHomeQuery(int todoListId)
	{
		TodoListId = todoListId;
	}
	public GetHomeQuery(string stringDate)
	{
		StringDate = stringDate;
	}
	public GetHomeQuery(int todoListId, string stringDate)
	{
		TodoListId = todoListId;
		StringDate = stringDate;
	}
	public GetHomeQuery(bool completed)
	{
		Completed = completed;
	}
	public GetHomeQuery(int todoListId, bool completed)
	{
		TodoListId = todoListId;
		Completed = completed;
	}
	public GetHomeQuery(string stringDate, bool completed)
	{
		StringDate = stringDate;
		Completed = completed;
	}
	public GetHomeQuery(int todoListId, string stringDate, bool completed)
	{
		TodoListId = todoListId;
		StringDate = stringDate;
		Completed = completed;
	}
	public int? TodoListId { get; set; }
	public string? StringDate { get; set; }
	public bool? Completed { get; set; }
}
