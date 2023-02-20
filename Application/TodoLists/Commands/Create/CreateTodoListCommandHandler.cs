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
		await _db.SaveChangesAsync(cancellationToken);
		if(mapped.Id < 1)
		{
			throw new DatabaseException(mapped.Id);
		}
		return mapped.Id;
	}
}
