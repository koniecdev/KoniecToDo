using Shared.TodoLists.Commands;

namespace Application.TodoLists.Commands;
public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public CreateTodoListCommandHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
	{
		var mapped = _mapper.Map<TodoList>(request);
		_db.TodoLists.Add(mapped);
		int id = await _db.SaveChangesAsync(cancellationToken);
		if(id < 1)
		{
			throw new DatabaseException(id);
		}
		return id;
	}
}
