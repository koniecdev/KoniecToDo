using Application.TodoLists.Queries.GetAll;
using Shared.TodoLists.Queries.GetAll;

namespace Application.UnitTests;

[Collection("QueryCollection")]
public class GetTodoListsQueryHandlerTest : QueryTestFixtures
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly GetTodoListsQueryHandler _handler;
	public GetTodoListsQueryHandlerTest(QueryTestFixtures fixtures)
	{
		_db = fixtures.Db;
		_mapper = fixtures.Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestGetTodoListsQueryHandler()
	{
		var response = await _handler.Handle(new GetTodoListsQuery(), Token);
		response.TodoLists?.Count.ShouldBeGreaterThan(0);
	}
}