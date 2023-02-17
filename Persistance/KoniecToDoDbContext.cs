using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using System.Reflection;

namespace Persistance;

public class KoniecToDoDbContext : DbContext, IKoniecToDoDbContext
{
	public KoniecToDoDbContext()
	{
	}
	public KoniecToDoDbContext(DbContextOptions<KoniecToDoDbContext> options) : base(options)
	{
	}

	public virtual DbSet<Priority>? Priorities { get; set; }
	public virtual DbSet<TodoTask>? TodoTasks { get; set; }
	public virtual DbSet<TodoList>? TodoLists { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
	{
		foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
		{
			switch (entry.State)
			{
				case EntityState.Added:
					entry.Entity.StatusId = 1;
					break;
				case EntityState.Deleted:
					entry.Entity.StatusId = 0;
					entry.State = EntityState.Modified;
					break;
			}
		}
		return base.SaveChangesAsync(cancellationToken);
	}
}