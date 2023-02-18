using Application.Priorities.Commands;
using Shared.Priorities.Commands;

namespace Application.UnitTests;

public class CreatePriorityCommandHandlerTest : CommandTestBase
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly CreatePriorityCommandHandler _handler;
	public CreatePriorityCommandHandlerTest()
	{
		_db = Db;
		_mapper = Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestCreatePriorityCommandHandler()
	{
		var response = await _handler.Handle(new CreatePriorityCommand() { Color = "#ffffff", Level = 1 }, Token);
		response.ShouldBeGreaterThan(0);
	}
}