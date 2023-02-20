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
	public int? TodoListId { get; set; }
	public string? StringDate { get; set; }
}
