using Shared.TodoLists.Commands;
namespace Application.TodoLists.Commands;
public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
{
	public UpdateTodoListCommandValidator()
	{
		RuleFor(m => m.Id).GreaterThan(0).LessThan(int.MaxValue);
		RuleFor(m => m.Name).MinimumLength(1).MaximumLength(100);
	}
}
