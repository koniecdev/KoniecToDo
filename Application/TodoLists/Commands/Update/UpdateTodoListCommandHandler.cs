using Shared.TodoLists.Commands;

namespace Application.TodoLists.Commands;
public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand, Unit>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public UpdateTodoListCommandHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<Unit> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
	{
		var fromDb = await _db.TodoLists.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(request.Id);
		}
		_mapper.Map(request, fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
