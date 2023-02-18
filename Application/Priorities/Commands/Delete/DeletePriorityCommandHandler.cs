using Shared.TodoLists.Commands;

namespace Application.TodoLists.Commands;
public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand, Unit>
{
	private readonly IKoniecToDoDbContext _db;
	public DeleteTodoListCommandHandler(IKoniecToDoDbContext db)
	{
		_db = db;
	}
	public async Task<Unit> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
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
