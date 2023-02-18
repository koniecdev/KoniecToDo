namespace Shared.TodoLists.Commands;
public class DeleteTodoListCommand : IRequest<Unit>
{
	public DeleteTodoListCommand()
	{
	}
	public int Id { get; set; }
}
