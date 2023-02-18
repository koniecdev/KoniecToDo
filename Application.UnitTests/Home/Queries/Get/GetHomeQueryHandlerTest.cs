using Application.Home.Queries.Get;
using Shared.Home.Queries.Get;

namespace Application.UnitTests;

[Collection("QueryCollection")]
public class GetHomeQueryHandlerTest : QueryTestFixtures
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly GetHomeQueryHandler _handler;
	public GetHomeQueryHandlerTest(QueryTestFixtures fixtures)
	{
		_db = fixtures.Db;
		_mapper = fixtures.Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task GetHomeQueryTest()
	{
		var response = await _handler.Handle(new GetHomeQuery(), Token);
		(response.TodoLists?.Count == 2 && response.TodoTasks?.Count == 1).ShouldBe(true);
	}
}