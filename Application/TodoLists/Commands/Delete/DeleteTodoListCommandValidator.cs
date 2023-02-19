using Shared.TodoLists.Commands;
namespace Application.TodoLists.Commands;
public class DeleteTodoListCommandValidator : AbstractValidator<DeleteTodoListCommand>
{
	public DeleteTodoListCommandValidator()
	{
		RuleFor(m => m.Id).GreaterThan(0).LessThan(int.MaxValue);
	}
}
