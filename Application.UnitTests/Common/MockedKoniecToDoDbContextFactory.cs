using Persistance;
using Domain.Entities;
using Moq;
using System;


namespace Application.UnitTests;

public static class MockedKoniecToDoDbContextFactory
{
	public static Mock<KoniecToDoDbContext> Create()
	{
		var dateTime = new DateTime(2000, 1, 1);
		var dateTimeMock = new Mock<IDateTime>();
		dateTimeMock.Setup(m => m.Now).Returns(dateTime);

		var options = new DbContextOptionsBuilder<KoniecToDoDbContext>()
			.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

		var mock = new Mock<KoniecToDoDbContext>(options) { CallBase = true };

		var context = mock.Object;

		context.Database.EnsureCreated();

		var prio1 = new Priority() { Id = 1, StatusId = 1, Color = "#ff0000", Level = 0 };
		context.Priorities.Add(prio1);
		var prio2 = new Priority() { Id = 2, StatusId = 1, Color = "#00ff00", Level = 1 };
		context.Priorities.Add(prio2);

		var todoList1 = new TodoList() { Id = 1, StatusId = 1, Name = "List #1"};
		context.TodoLists.Add(todoList1);
		var todoList2 = new TodoList() { Id = 2, StatusId = 1, Name = "List #2" };
		context.TodoLists.Add(todoList2);


		var todoTask1 = new TodoTask() { Id = 1, StatusId = 1, Deadline = DateTime.Now.AddDays(1), Completed = false, Title = "Go to shop", PriorityId = 1, TodoListId = 1};
		context.TodoTasks.Add(todoTask1);
		var todoTask2 = new TodoTask() { Id = 2, StatusId = 1, Deadline = DateTime.Now.AddDays(2), Completed = false, Title = "Go to friend", PriorityId = 2, TodoListId = 1 };
		context.TodoTasks.Add(todoTask2);
		var todoTask3 = new TodoTask() { Id = 3, StatusId = 1, Deadline = DateTime.Now.AddDays(2), Completed = false, Title = "Buy some food", PriorityId = 2, TodoListId = 2 };
		context.TodoTasks.Add(todoTask3);

		context.SaveChanges();

		return mock;
	}

	public static void Destroy(KoniecToDoDbContext context)
	{
		context.Database.EnsureDeleted();
		context.Dispose();
	}

}
