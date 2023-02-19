using Shared.Priorities.Commands;
namespace Application.Priorities.Commands;
public class CreatePriorityCommandValidator : AbstractValidator<CreatePriorityCommand>
{
	public CreatePriorityCommandValidator()
	{
		RuleFor(m => m.Level).GreaterThanOrEqualTo(0).LessThan(10);
		RuleFor(m => m.Color).MinimumLength(4).MaximumLength(7).NotEmpty();
		RuleFor(m => m.Name).MinimumLength(2).MaximumLength(30).NotEmpty();
	}
}
