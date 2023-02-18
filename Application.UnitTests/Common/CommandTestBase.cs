using Application.Common.Interfaces;
using AutoMapper;
using Shared.Common.Mappings;
using Moq;
using System;
using System.Threading;
using Persistance;

namespace Application.UnitTests;

public class CommandTestBase : IDisposable
{
	protected KoniecToDoDbContext Db { get; private set; }
	protected IMapper Mapper { get; private set; }
	protected IDateTime DateTime { get; private set; }
	protected CancellationToken Token { get; private set; }
	public CommandTestBase()
	{
		Db = MockedKoniecToDoDbContextFactory.Create().Object;
		var configurationProvider = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<MappingProfile>();
		});
		Mapper = configurationProvider.CreateMapper();
		var dateTimeMock = new Mock<IDateTime>();
		dateTimeMock.Setup(m => m.Now).Returns(new DateTime(2025, 1, 1));
		DateTime = dateTimeMock.Object;
		Token = CancellationToken.None;
	}
	public void Dispose()
	{
		MockedKoniecToDoDbContextFactory.Destroy(Db);
		GC.SuppressFinalize(this);
	}
}
