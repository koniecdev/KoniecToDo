using Shared.Priorities.Commands;
namespace Application.Priorities.Commands;
public class DeletePriorityCommandValidator : AbstractValidator<DeletePriorityCommand>
{
	public DeletePriorityCommandValidator()
	{
		RuleFor(m => m.Id).GreaterThan(0).LessThan(int.MaxValue);
	}
}
