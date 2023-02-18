namespace Shared.TodoLists.Commands;
public class DeleteTodoListCommand : IRequest<Unit>
{
	public DeleteTodoListCommand(int id)
	{
		Id = id;
	}
	public int Id { get; set; }
}
