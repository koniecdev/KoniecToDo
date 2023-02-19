using Shared.TodoTasks.Commands;
namespace Application.TodoTasks.Commands;
public class DeleteTodoTaskCommandValidator : AbstractValidator<DeleteTodoTaskCommand>
{
	public DeleteTodoTaskCommandValidator()
	{
		RuleFor(m => m.Id).GreaterThan(0).LessThan(int.MaxValue);
	}
}
