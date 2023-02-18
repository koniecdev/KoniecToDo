namespace Shared.TodoTasks.Commands;
public class DeleteTodoTaskCommand : IRequest<Unit>
{
	public DeleteTodoTaskCommand()
	{
	}
	public int Id { get; set; }
}
