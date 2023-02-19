using Shared.ViewModels.Queries.GetTodoTask;

namespace Application.ViewModels.Queries.GetTaskLists;
public class GetTodoTaskQueryHandler : IRequestHandler<GetTodoTaskQuery, GetTodoTaskVm>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public GetTodoTaskQueryHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<GetTodoTaskVm> Handle(GetTodoTaskQuery request, CancellationToken cancellationToken)
	{
		GetTodoTaskVm vm = new();
		if(request.Id == null)
		{
			vm.TodoTask = new();
		}
		else
		{
			vm.TodoTask = _mapper.Map<GetTodoTaskDto>(await _db.TodoTasks.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken));
			if(vm.TodoTask == null)
			{
				throw new NotFoundException((int)request.Id);
			}
		}
		vm.TodoLists = _mapper.Map<List<GetTodoTaskTodoListDto>>(await _db.TodoLists.Where(m => m.StatusId != 0).ToListAsync(cancellationToken));
		vm.Priorities = _mapper.Map<List<GetTodoTaskPriorityDto>>(await _db.Priorities.Where(m => m.StatusId != 0).ToListAsync(cancellationToken));
		return vm;
	}
}
