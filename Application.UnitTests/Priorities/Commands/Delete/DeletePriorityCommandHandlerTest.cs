using Application.Priorities.Commands;
using Shared.Priorities.Commands;

namespace Application.UnitTests;

public class DeletePriorityCommandHandlerTest : CommandTestBase
{
	private readonly IKoniecToDoDbContext _db;
	private readonly DeletePriorityCommandHandler _handler;
	public DeletePriorityCommandHandlerTest()
	{
		_db = Db;
		_handler = new(_db);
	}

	[Fact]
	public async Task TestDeletePriorityCommandHandler()
	{
		await _handler.Handle(new DeletePriorityCommand(1), Token);
		var fromDb = await _db.Priorities.FirstOrDefaultAsync(m => m.Id == 1);
		fromDb?.StatusId.ShouldBe(0);
	}
}