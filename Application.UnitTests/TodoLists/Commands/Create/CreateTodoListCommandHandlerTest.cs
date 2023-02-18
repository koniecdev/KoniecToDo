using Application.TodoLists.Commands;
using Shared.TodoLists.Commands;

namespace Application.UnitTests;

public class CreateTodoListCommandHandlerTest : CommandTestBase
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly CreateTodoListCommandHandler _handler;
	public CreateTodoListCommandHandlerTest()
	{
		_db = Db;
		_mapper = Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestCreateTodoListCommandHandler()
	{
		var response = await _handler.Handle(new CreateTodoListCommand() { Name = "Test TodoList" }, Token);
		response.ShouldBeGreaterThan(0);
	}
}