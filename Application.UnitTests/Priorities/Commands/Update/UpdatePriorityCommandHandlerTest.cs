using Application.Priorities.Commands;
using Shared.Priorities.Commands;

namespace Application.UnitTests;

public class UpdatePriorityCommandHandlerTest : CommandTestBase
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly UpdatePriorityCommandHandler _handler;
	public UpdatePriorityCommandHandlerTest()
	{
		_db = Db;
		_mapper = Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestUpdatePriorityCommandHandler()
	{
		var fromDb = await _db.Priorities.FirstOrDefaultAsync(m => m.Id == 1);
		var updated = new UpdatePriorityCommand() { Id = 1, Color = "#ffffff" };
		await _handler.Handle(updated, Token);
		(fromDb?.Color.Equals(updated.Color)).ShouldBe(true);
	}
}