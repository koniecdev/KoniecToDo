using Application.ViewModels.Queries.GetHome;
using Shared.ViewModels.Queries.GetHome;

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
		(response.TodoLists?.Count == 2 && response.TodoTasks?.Count == 3 && response.SelectedTodoListId == null).ShouldBe(true);
	}

	[Fact]
	public async Task GetHomeQueryWithIdTest()
	{
		var response = await _handler.Handle(new GetHomeQuery(1), Token);
		(response.TodoLists?.Count == 2 && response.TodoTasks?.Count == 2 && response.SelectedTodoListId == 1).ShouldBe(true);
	}

	[Fact]
	public async Task GetHomeQueryWithDateTest()
	{
		var response = await _handler.Handle(new GetHomeQuery("2023-02-21"), Token);
		(response.TodoLists?.Count == 2 && response.TodoTasks?.Count == 2 && response.SelectedTodoListId == null).ShouldBe(true);
	}

	[Fact]
	public async Task GetHomeQueryWithIdDateTest()
	{
		var response = await _handler.Handle(new GetHomeQuery(2, "2023-02-21"), Token);
		(response.TodoLists?.Count == 2 && response.TodoTasks?.Count == 1 && response.SelectedTodoListId == 2).ShouldBe(true);
	}
}