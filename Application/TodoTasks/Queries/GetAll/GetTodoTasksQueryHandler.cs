using Shared.TodoTasks.Queries.GetAll;

namespace Application.TodoTasks.Queries.GetAll;
public class GetTodoTasksQueryHandler : IRequestHandler<GetTodoTasksQuery, GetTodoTasksVm>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public GetTodoTasksQueryHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<GetTodoTasksVm> Handle(GetTodoTasksQuery request, CancellationToken cancellationToken)
	{
		var fromDb = await _db.TodoTasks.ToListAsync(cancellationToken);
		return new GetTodoTasksVm(_mapper.Map<List<GetTodoTasksDto>>(fromDb));
	}
}
