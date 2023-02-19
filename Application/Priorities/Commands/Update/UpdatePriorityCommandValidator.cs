using Shared.Priorities.Commands;
namespace Application.Priorities.Commands;
public class UpdatePriorityCommandValidator : AbstractValidator<UpdatePriorityCommand>
{
	public UpdatePriorityCommandValidator()
	{
		RuleFor(m => m.Level).GreaterThanOrEqualTo(0).LessThan(10);
		RuleFor(m => m.Color).MinimumLength(4).MaximumLength(7);
		RuleFor(m => m.Name).MinimumLength(2).MaximumLength(30);
	}
}
