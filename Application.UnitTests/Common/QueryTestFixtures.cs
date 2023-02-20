using Infrastructure.Services;
using Persistance;
using Shared.Common.Mappings;
using System;
using System.Threading;

namespace Application.UnitTests;

public class QueryTestFixtures : IDisposable
{
	public KoniecToDoDbContext Db { get; private set; }
	public IMapper Mapper { get; private set; }
	public IDateTime DateTime { get; private set; }
	protected CancellationToken Token { get; private set; }

	public QueryTestFixtures()
	{
		Db = MockedKoniecToDoDbContextFactory.Create().Object;
		var configurationProvider = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<MappingProfile>();
		});
		Mapper = configurationProvider.CreateMapper();
		Token = CancellationToken.None;
		DateTime = new DateTimeService();
	}
	public void Dispose()
	{
		MockedKoniecToDoDbContextFactory.Destroy(Db);
		GC.SuppressFinalize(this);
	}
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<QueryTestFixtures> {  }