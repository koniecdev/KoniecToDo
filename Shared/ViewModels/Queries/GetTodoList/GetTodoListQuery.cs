namespace Shared.ViewModels.Queries.GetTodoList;
public class GetTodoListQuery : IRequest<GetTodoListVm>
{
	public GetTodoListQuery()
	{
	}
	public GetTodoListQuery(int id)
	{
		Id = id;
	}
	public int? Id { get; set; }
}
