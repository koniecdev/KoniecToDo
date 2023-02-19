namespace Application.Common.Interfaces;

public interface IKoniecToDoDbContext
{
	DbSet<Priority> Priorities { get; set; }
	DbSet<TodoTask> TodoTasks { get; set; }
	DbSet<TodoList> TodoLists { get; set; }
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
