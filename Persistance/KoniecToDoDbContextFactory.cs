namespace Persistance;
public class KoniecToDoDbContextFactory : DesignTimeDbContextFactoryBase<KoniecToDoDbContext>
{
	protected override KoniecToDoDbContext CreateNewInstance(DbContextOptions<KoniecToDoDbContext> options)
	{
		return new KoniecToDoDbContext(options);
	}
}