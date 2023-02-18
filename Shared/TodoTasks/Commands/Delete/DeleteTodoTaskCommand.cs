namespace Shared.TodoTasks.Commands;
public class DeleteTodoTaskCommand : IRequest<Unit>
{
	public DeleteTodoTaskCommand(int id)
	{
		Id = id;
	}
	public int Id { get; set; }
}
