namespace Shared.Priorities.Commands;
public class DeletePriorityCommand : IRequest<Unit>
{
	public DeletePriorityCommand(int id)
	{
		Id = id;
	}

	public int Id { get; set; }
}
