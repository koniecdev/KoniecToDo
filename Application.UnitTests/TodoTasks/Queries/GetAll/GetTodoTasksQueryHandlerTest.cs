using Application.TodoTasks.Queries.GetAll;
using Shared.TodoTasks.Queries.GetAll;

namespace Application.UnitTests;

[Collection("QueryCollection")]
public class GetTodoTasksQueryHandlerTest : QueryTestFixtures
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly GetTodoTasksQueryHandler _handler;
	public GetTodoTasksQueryHandlerTest(QueryTestFixtures fixtures)
	{
		_db = fixtures.Db;
		_mapper = fixtures.Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestGetPrioritiesQueryHandler()
	{
		var response = await _handler.Handle(new GetTodoTasksQuery(), Token);
		response.TodoTasks?.Count.ShouldBeGreaterThan(0);
	}
}