using Shared.ViewModels.Queries.GetHome;

namespace Application.ViewModels.Queries.GetHome;
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
		GetHomeVm vm = new()
		{
			TodoLists = _mapper.Map<List<GetHomeTodoListDto>>(await _db.TodoLists.Where(m => m.StatusId != 0).ToListAsync(cancellationToken)),
			TodoTasks = new List<GetHomeTodoTaskDto>()
		};
		if (request.TodoListId == null)
		{
			vm.SelectedTodoListId = await _db.TodoLists.OrderByDescending(m => m.Id).Select(m => m.Id).FirstOrDefaultAsync(cancellationToken);
			if(vm.SelectedTodoListId == 0)
			{
				vm.SelectedTodoListId = null;
			}
		}
		else if(request.TodoListId > 0)
		{
			vm.SelectedTodoListId = request.TodoListId;
		}
		if (vm.SelectedTodoListId > 0)
		{
			vm.TodoTasks = _mapper.Map<List<GetHomeTodoTaskDto>>(await _db.TodoTasks.Include(m => m.Priority)
			.Where(m => m.TodoListId == vm.SelectedTodoListId).ToListAsync(cancellationToken));
		}
		return vm;
	}
}
