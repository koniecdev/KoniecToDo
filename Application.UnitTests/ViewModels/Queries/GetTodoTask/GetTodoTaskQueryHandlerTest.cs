using Application.ViewModels.Queries.GetTaskLists;
using Shared.ViewModels.Queries.GetTodoTask;

namespace Application.UnitTests;

[Collection("QueryCollection")]
public class GetTodoTaskQueryHandlerTest : QueryTestFixtures
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly GetTodoTaskQueryHandler _handler;
	public GetTodoTaskQueryHandlerTest(QueryTestFixtures fixtures)
	{
		_db = fixtures.Db;
		_mapper = fixtures.Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestGetTodoTaskQueryHandler()
	{
		var response = await _handler.Handle(new GetTodoTaskQuery(), Token);
		(response.TodoLists?.Count == 2 && response.Priorities?.Count == 3 && response.TodoTask.Id == null).ShouldBe(true);
	}

	[Fact]
	public async Task TestGetTodoTaskQueryHandlerWithId()
	{
		var response = await _handler.Handle(new GetTodoTaskQuery(1), Token);
		(response.TodoLists?.Count == 2 && response.Priorities?.Count == 3 && response.TodoTask.Id == 1).ShouldBe(true);
	}
}