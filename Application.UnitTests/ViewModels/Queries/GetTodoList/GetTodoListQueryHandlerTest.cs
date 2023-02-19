using Application.ViewModels.Queries.GetTodoList;
using Shared.ViewModels.Queries.GetTodoList;

namespace Application.UnitTests;

[Collection("QueryCollection")]
public class GetTodoListQueryHandlerTest : QueryTestFixtures
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly GetTodoListQueryHandler _handler;
	public GetTodoListQueryHandlerTest(QueryTestFixtures fixtures)
	{
		_db = fixtures.Db;
		_mapper = fixtures.Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestGetTodoListQueryHandler()
	{
		var response = await _handler.Handle(new GetTodoListQuery(), Token);
		string.IsNullOrEmpty(response.TodoList?.Name).ShouldBe(true);
	}

	[Fact]
	public async Task TestGetTodoListQueryHandlerWithId()
	{
		var response = await _handler.Handle(new GetTodoListQuery(1), Token);
		string.IsNullOrEmpty(response.TodoList?.Name).ShouldBe(false);
	}
}