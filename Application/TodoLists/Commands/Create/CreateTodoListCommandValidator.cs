using Shared.TodoLists.Commands;
namespace Application.TodoLists.Commands;
public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
{
	public CreateTodoListCommandValidator()
	{
		RuleFor(m => m.Name).MinimumLength(1).MaximumLength(100).NotEmpty();
	}
}
