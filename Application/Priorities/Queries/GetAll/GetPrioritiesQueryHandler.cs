using Shared.Priorities.Queries.GetAll;

namespace Application.Priorities.Queries.GetAll;
public class GetPrioritiesQueryHandler : IRequestHandler<GetPrioritiesQuery, GetPrioritiesVm>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public GetPrioritiesQueryHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<GetPrioritiesVm> Handle(GetPrioritiesQuery request, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Priorities.ToListAsync(cancellationToken);
		return new GetPrioritiesVm(_mapper.Map<List<GetPrioritiesDto>>(fromDb));
	}
}
