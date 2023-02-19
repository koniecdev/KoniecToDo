using Domain.Entities;
using System.Diagnostics;

namespace Persistance;
public class DbInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
		try
		{
			modelBuilder.Entity<Priority>().HasData(
				new Priority { Id = 1, Level = 0, Color = "#ff0000", StatusId = 1, Name = "Very important" },
				new Priority { Id = 2, Level = 0, Color = "#ff6D0A", StatusId = 1, Name = "Important" },
				new Priority { Id = 3, Level = 0, Color = "#00ff00", StatusId = 1, Name = "Normal" }
			);
		}
		catch
		{
			Debug.WriteLine("Db already have data");
		}
		
	}
}