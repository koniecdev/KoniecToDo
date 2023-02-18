using Application.TodoLists.Commands;
using Shared.TodoLists.Commands;

namespace Application.UnitTests;

public class DeleteTodoListCommandHandlerTest : CommandTestBase
{
	private readonly IKoniecToDoDbContext _db;
	private readonly DeleteTodoListCommandHandler _handler;
	public DeleteTodoListCommandHandlerTest()
	{
		_db = Db;
		_handler = new(_db);
	}

	[Fact]
	public async Task TestDeleteTodoListCommandHandler()
	{
		await _handler.Handle(new DeleteTodoListCommand(1), Token);
		var fromDb = await _db.TodoLists.FirstOrDefaultAsync(m => m.Id == 1);
		fromDb?.StatusId.ShouldBe(0);
	}
}