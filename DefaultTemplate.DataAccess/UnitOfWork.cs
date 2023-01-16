using Microsoft.Extensions.DependencyInjection;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly DefaultContext _context;
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWork(DefaultContext context, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _context = context;
    }

    public ICrudRepository<TDomain, TSearchQuery> GetRepository<TDomain, TSearchQuery>()
        where TDomain : class
        where TSearchQuery : SearchQuery
    {
        return _serviceProvider.GetRequiredService(typeof(ICrudRepository<TDomain, TSearchQuery>)) as ICrudRepository<TDomain, TSearchQuery>;
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}