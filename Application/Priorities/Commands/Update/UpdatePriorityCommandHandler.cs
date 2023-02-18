using Shared.Priorities.Commands;

namespace Application.Priorities.Commands;
public class UpdatePriorityCommandHandler : IRequestHandler<UpdatePriorityCommand, Unit>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public UpdatePriorityCommandHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<Unit> Handle(UpdatePriorityCommand request, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Priorities.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(request.Id);
		}
		_mapper.Map(request, fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
