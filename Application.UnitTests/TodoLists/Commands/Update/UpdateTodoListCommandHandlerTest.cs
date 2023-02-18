using Application.TodoLists.Commands;
using Shared.TodoLists.Commands;

namespace Application.UnitTests;

public class UpdateTodoListCommandHandlerTest : CommandTestBase
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly UpdateTodoListCommandHandler _handler;
	public UpdateTodoListCommandHandlerTest()
	{
		_db = Db;
		_mapper = Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestUpdateTodoListCommandHandler()
	{
		var fromDb = await _db.TodoLists.FirstOrDefaultAsync(m => m.Id == 1);
		var updated = new UpdateTodoListCommand() { Id = 1, Name = "Updated name" };
		await _handler.Handle(updated, Token);
		(fromDb?.Name.Equals(updated.Name)).ShouldBe(true);
	}
}