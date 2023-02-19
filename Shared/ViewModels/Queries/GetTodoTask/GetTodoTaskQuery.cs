namespace Shared.ViewModels.Queries.GetTodoTask;

public class GetTodoTaskQuery : IRequest<GetTodoTaskVm>
{
	public GetTodoTaskQuery()
	{
	}
	public GetTodoTaskQuery(int id)
	{
		Id = id;
	}
	public int? Id { get; set; }
}
