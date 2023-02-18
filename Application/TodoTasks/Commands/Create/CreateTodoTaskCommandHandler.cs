using Shared.TodoTasks.Commands;

namespace Application.TodoTasks.Commands;
public class CreateTodoTaskCommandHandler : IRequestHandler<CreateTodoTaskCommand, int>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public CreateTodoTaskCommandHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<int> Handle(CreateTodoTaskCommand request, CancellationToken cancellationToken)
	{
		var mapped = _mapper.Map<TodoTask>(request);
		_db.TodoTasks.Add(mapped);
		int id = await _db.SaveChangesAsync(cancellationToken);
		if(id < 1)
		{
			throw new DatabaseException(id);
		}
		return id;
	}
}
