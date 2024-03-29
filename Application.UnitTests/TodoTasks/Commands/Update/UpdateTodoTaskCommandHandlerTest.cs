﻿using Application.TodoTasks.Commands;
using Shared.TodoTasks.Commands;

namespace Application.UnitTests;

public class UpdateTodoTaskCommandHandlerTest : CommandTestBase
{
	private readonly IKoniecToDoDbContext _db;
	private readonly IMapper _mapper;
	private readonly UpdateTodoTaskCommandHandler _handler;
	public UpdateTodoTaskCommandHandlerTest()
	{
		_db = Db;
		_mapper = Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task TestUpdateTodoTaskCommandHandler()
	{
		var fromDb = await _db.TodoTasks.FirstOrDefaultAsync(m => m.Id == 1);
		var updated = new UpdateTodoTaskCommand() { Id = 1, Title = "Updated Title"};
		await _handler.Handle(updated, Token);
		(fromDb?.Title.Equals(updated.Title)).ShouldBe(true);
	}

	[Fact]
	public async Task TestTodoTaskUpdateChecking()
	{
		var fromDb = await _db.TodoTasks.FirstOrDefaultAsync(m => m.Id == 1);
		var updated = new UpdateTodoTaskCommand() { Id = 1, Completed = true };
		await _handler.Handle(updated, Token);
		fromDb?.Completed.ShouldBe(true);
	}

	[Fact]
	public async Task TestTodoTaskUpdateUpdating()
	{
		var fromDb = await _db.TodoTasks.FirstOrDefaultAsync(m => m.Id == 3);
		var updated = new UpdateTodoTaskCommand() { Id = 3, Title = "testing title" };
		await _handler.Handle(updated, Token);
		fromDb?.Completed.ShouldBe(true);
	}
}