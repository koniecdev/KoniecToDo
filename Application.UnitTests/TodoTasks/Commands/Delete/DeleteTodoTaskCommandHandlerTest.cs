using Application.TodoTasks.Commands;
using Shared.TodoTasks.Commands;

namespace Application.UnitTests;

public class DeleteTodoTaskCommandHandlerTest : CommandTestBase
{
	private readonly IKoniecToDoDbContext _db;
	private readonly DeleteTodoTaskCommandHandler _handler;
	public DeleteTodoTaskCommandHandlerTest()
	{
		_db = Db;
		_handler = new(_db);
	}

	[Fact]
	public async Task TestDeleteTodoTaskCommandHandler()
	{
		await _handler.Handle(new DeleteTodoTaskCommand(1), Token);
		var fromDb = await _db.TodoTasks.FirstOrDefaultAsync(m => m.Id == 1);
		fromDb?.StatusId.ShouldBe(0);
	}
}