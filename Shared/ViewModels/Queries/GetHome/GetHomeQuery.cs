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
	public int? TodoListId { get; set; }
}
