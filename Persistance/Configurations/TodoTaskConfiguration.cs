using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;
public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
{
	public void Configure(EntityTypeBuilder<TodoTask> builder)
	{
		builder.Property(m => m.Title).HasMaxLength(200).IsRequired();
		builder.Property(m => m.Completed).IsRequired();
		builder.Property(m => m.Deadline).IsRequired();
		builder.Property(m => m.PriorityId).IsRequired();
		builder.Property(m => m.TodoListId).IsRequired();
	}
}
