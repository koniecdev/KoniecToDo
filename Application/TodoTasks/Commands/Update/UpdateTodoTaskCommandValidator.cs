using Shared.TodoTasks.Commands;
namespace Application.TodoTasks.Commands;
public class UpdateTodoTaskCommandValidator : AbstractValidator<UpdateTodoTaskCommand>
{
	private readonly IDateTime _dateTime;
	public UpdateTodoTaskCommandValidator(IDateTime dateTime)
	{
		_dateTime = dateTime;
		RuleFor(m => m.Title).MinimumLength(3).MaximumLength(150);
		RuleFor(m => m.PriorityId).GreaterThan(0).LessThan(int.MaxValue);
		RuleFor(m => m.TodoListId).GreaterThan(0).LessThan(int.MaxValue);
		RuleFor(m => m.Deadline).GreaterThanOrEqualTo(_dateTime.Now);
	}
}
