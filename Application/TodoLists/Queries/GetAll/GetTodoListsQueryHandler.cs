using Shared.TodoLists.Queries.GetAll;

namespace Application.TodoLists.Queries.GetAll;
public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, GetTodoListsVm>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public GetTodoListsQueryHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<GetTodoListsVm> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
	{
		var fromDb = await _db.TodoLists.ToListAsync(cancellationToken);
		return new GetTodoListsVm(_mapper.Map<List<GetTodoListsDto>>(fromDb));
	}
}
