using Application.TodoTasks.Commands;
using Shared.TodoTasks.Commands;

namespace Application.UnitTests;

public class CreateTodoTaskCommandHandlerTest : CommandTestBase
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly CreateTodoTaskCommandHandler _handler;
	public CreateTodoTaskCommandHandlerTest()
	{
		_db = Db;
		_mapper = Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestCreateTodoTaskCommandHandler()
	{
		var response = await _handler.Handle(new CreateTodoTaskCommand() { Deadline = DateTime.Now, Title = "Test Task", TodoListId = 1, PriorityId = 1}, Token);
		response.ShouldBeGreaterThan(0);
	}
}