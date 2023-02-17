using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;
public class PriorityConfiguration :IEntityTypeConfiguration<Priority>
{
	public void Configure(EntityTypeBuilder<Priority> builder)
	{
		builder.Property(m => m.Id).IsRequired();
		builder.Property(m => m.Color).HasMaxLength(7).IsRequired();
		builder.Property(m => m.Level).IsRequired();
	}
}
