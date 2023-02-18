using Shared.Home.Queries.Get;

namespace Application.Home.Queries.Get;
public class GetHomeQueryHandler : IRequestHandler<GetHomeQuery, GetHomeVm>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public GetHomeQueryHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<GetHomeVm> Handle(GetHomeQuery request, CancellationToken cancellationToken)
	{
		int newestToDoListId = await _db.TodoLists.OrderByDescending(m=>m.Id).Select(m=>m.Id).FirstOrDefaultAsync(cancellationToken); 
		GetHomeVm vm = new()
		{
			TodoLists = _mapper.Map<List<GetHomeTodoListDto>>(await _db.TodoLists.Where(m => m.StatusId != 0).ToListAsync(cancellationToken)),
			TodoTasks = _mapper.Map<List<GetHomeTodoTaskDto>>(await _db.TodoTasks.Include(m=>m.Priority)
			.Where(m=>m.TodoListId == newestToDoListId).ToListAsync(cancellationToken))
		};
		return vm;
	}
}
