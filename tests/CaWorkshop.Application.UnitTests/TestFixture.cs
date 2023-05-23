using AutoMapper;
using CaWorkshop.Infrastructure.Data;

namespace CaWorkshop.Application.UnitTests;

public class TestFixture : IDisposable
{
    private readonly DbContextFactory _contextFactory;

    public TestFixture()
    {
        _contextFactory = new DbContextFactory();

        Context = _contextFactory.Create();
        Mapper = MapperFactory.Create();
    }

    public ApplicationDbContext Context { get; }

    public IMapper Mapper { get; }

    public void Dispose()
    {
        _contextFactory.Dispose();
    }
}


[CollectionDefinition(nameof(QueryCollection))]
public class QueryCollection : ICollectionFixture<TestFixture> { }