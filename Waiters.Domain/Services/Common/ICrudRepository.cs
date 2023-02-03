using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Services.Common;


public interface ICrudRepository<TDomain, in TSearchQuery> 
    where TDomain : class
    where TSearchQuery : SearchQuery 
{
    Task<TDomain?> GetAsync(Guid id);
    Task<TDomain?> FirstOrDefault(TSearchQuery query);
    Task<IReadOnlyList<TDomain>> GetAsync(TSearchQuery query);
    Task<SearchResult<TDomain>> SearchAsync(TSearchQuery query);
    Task SaveAsync(TDomain model, bool forceId);
    Task<bool> Any(TSearchQuery query);
    Task<int> Count(TSearchQuery query);
    Task Delete(Guid id);
}