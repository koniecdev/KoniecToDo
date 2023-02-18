using Application.Priorities.Queries.GetAll;
using Shared.Priorities.Queries.GetAll;

namespace Application.UnitTests;

[Collection("QueryCollection")]
public class GetPrioritiesQueryHandlerTest : QueryTestFixtures
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly GetPrioritiesQueryHandler _handler;
	public GetPrioritiesQueryHandlerTest(QueryTestFixtures fixtures)
	{
		_db = fixtures.Db;
		_mapper = fixtures.Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestGetPrioritiesQueryHandler()
	{
		var response = await _handler.Handle(new GetPrioritiesQuery(), Token);
		response.Priorities?.Count.ShouldBeGreaterThan(0);
	}
}