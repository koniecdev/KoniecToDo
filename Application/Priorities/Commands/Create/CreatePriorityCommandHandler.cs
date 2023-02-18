using Shared.Priorities.Commands;

namespace Application.Priorities.Commands;
public class CreatePriorityCommandHandler : IRequestHandler<CreatePriorityCommand, int>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public CreatePriorityCommandHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<int> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
	{
		var mapped = _mapper.Map<Priority>(request);
		_db.Priorities.Add(mapped);
		int id = await _db.SaveChangesAsync(cancellationToken);
		if(id < 1)
		{
			throw new DatabaseException(id);
		}
		return id;
	}
}
