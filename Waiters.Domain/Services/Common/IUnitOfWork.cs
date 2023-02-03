using Microsoft.EntityFrameworkCore;
using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Services.Common;

public interface IUnitOfWork
{
    ICrudRepository<TDomain, TSearchQuery> GetRepository<TDomain, TSearchQuery>()
        where TDomain : class
        where TSearchQuery : SearchQuery;
    Task SaveChangesAsync();
}