﻿using Shared.TodoTasks.Commands;

namespace Application.TodoTasks.Commands;
public class UpdateTodoTaskCommandHandler : IRequestHandler<UpdateTodoTaskCommand, Unit>
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	public UpdateTodoTaskCommandHandler(IKoniecToDoDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<Unit> Handle(UpdateTodoTaskCommand request, CancellationToken cancellationToken)
	{
		var fromDb = await _db.TodoTasks.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(request.Id);
		}
		_mapper.Map(request, fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
