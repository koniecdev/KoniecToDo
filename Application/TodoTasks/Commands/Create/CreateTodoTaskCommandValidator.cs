using Shared.TodoTasks.Commands;
namespace Application.TodoTasks.Commands;
public class CreateTodoTaskCommandValidator : AbstractValidator<CreateTodoTaskCommand>
{
	public CreateTodoTaskCommandValidator()
	{
		RuleFor(m => m.Title).MinimumLength(3).MaximumLength(150).NotEmpty();
		RuleFor(m => m.PriorityId).GreaterThan(0).LessThan(int.MaxValue).NotEmpty();
		RuleFor(m => m.TodoListId).GreaterThan(0).LessThan(int.MaxValue).NotEmpty();
		RuleFor(m => m.Deadline).NotEmpty();
	}
}
