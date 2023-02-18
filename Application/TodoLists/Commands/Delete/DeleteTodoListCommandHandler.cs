using Shared.Priorities.Commands;

namespace Application.Priorities.Commands;
public class DeletePriorityCommandHandler : IRequestHandler<DeletePriorityCommand, Unit>
{
	private readonly IKoniecToDoDbContext _db;
	public DeletePriorityCommandHandler(IKoniecToDoDbContext db)
	{
		_db = db;
	}
	public async Task<Unit> Handle(DeletePriorityCommand request, CancellationToken cancellationToken)
	{
		var fromDb = await _db.TodoLists.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(request.Id);
		}
		_db.TodoLists.Remove(fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
