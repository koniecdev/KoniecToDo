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
		if(request.Completed != true)
		{
			request.Completed = false;
		}
		if(request.TodoListId > 0 && request.StringDate is null)
		{
			vm.TodoTasks = _mapper.Map<List<GetHomeTodoTaskDto>>(await _db.TodoTasks.Include(m => m.TodoList).Include(m => m.Priority)
			.Where(m => m.StatusId != 0 && m.Completed == request.Completed && m.TodoListId == request.TodoListId).ToListAsync(cancellationToken));
			vm.SelectedTodoListId = request.TodoListId;
		}
		else if (request.TodoListId is null && request.StringDate is not null)
		{
			var dateComponents = request.StringDate.Split("-");
			vm.TodoTasks = _mapper.Map<List<GetHomeTodoTaskDto>>(await _db.TodoTasks.Include(m => m.TodoList).Include(m => m.Priority)
				.Where(m => m.StatusId != 0 && m.Completed == request.Completed && m.TodoList.StatusId != 0 && 
				m.Deadline.Date == new DateTime(Convert.ToInt32(dateComponents[0]), Convert.ToInt32(dateComponents[1]), Convert.ToInt32(dateComponents[2])))
				.ToListAsync(cancellationToken));
		}
		else if (request.TodoListId > 0 && request.StringDate is not null)
		{
			var dateComponents = request.StringDate.Split("-");
			vm.TodoTasks = _mapper.Map<List<GetHomeTodoTaskDto>>(await _db.TodoTasks.Include(m => m.TodoList).Include(m => m.Priority)
				.Where(m => m.StatusId != 0 && m.Completed == request.Completed && m.TodoListId == request.TodoListId &&
				m.Deadline.Date == new DateTime(Convert.ToInt32(dateComponents[0]), Convert.ToInt32(dateComponents[1]), Convert.ToInt32(dateComponents[2])))
				.ToListAsync(cancellationToken));
			vm.SelectedTodoListId = request.TodoListId;
		}
		else
		{
			vm.TodoTasks = _mapper.Map<List<GetHomeTodoTaskDto>>(await _db.TodoTasks.Include(m => m.TodoList).Include(m => m.Priority)
				.Where(m => m.StatusId != 0 && m.Completed == request.Completed && m.TodoList.StatusId != 0).ToListAsync(cancellationToken));
		}
		return vm;
	}
}
