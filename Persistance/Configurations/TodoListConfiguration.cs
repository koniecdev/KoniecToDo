using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;
public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
	public void Configure(EntityTypeBuilder<TodoList> builder)
	{
		builder.Property(m => m.Id).IsRequired();
		builder.Property(m => m.Name).IsRequired();
	}
}
