using Shared.TodoTasks.Commands;

namespace Application.TodoTasks.Commands;
public class DeleteTodoTaskCommandHandler : IRequestHandler<DeleteTodoTaskCommand, Unit>
{
	private readonly IKoniecToDoDbContext _db;
	public DeleteTodoTaskCommandHandler(IKoniecToDoDbContext db)
	{
		_db = db;
	}
	public async Task<Unit> Handle(DeleteTodoTaskCommand request, CancellationToken cancellationToken)
	{
		var fromDb = await _db.TodoTasks.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(request.Id);
		}
		_db.TodoTasks.Remove(fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
