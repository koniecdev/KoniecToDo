using Shared.ViewModels.Queries.GetTodoList;

namespace Application.ViewModels.Queries.GetTodoList;
public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, GetTodoListVm>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public GetTodoListQueryHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<GetTodoListVm> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
	{
		GetTodoListVm vm = new();
		if(request.Id == null)
		{
			vm.TodoList = new();
		}
		else
		{
			vm.TodoList = _mapper.Map<GetTodoListDto>(await _db.TodoLists.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken));
			if(vm.TodoList == null)
			{
				throw new NotFoundException((int)request.Id);
			}
		}
		return vm;
	}
}
