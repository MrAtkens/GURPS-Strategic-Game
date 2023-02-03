using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Services.Common;

public interface ICrudService<TDomain, in TSearchQuery>
    where TSearchQuery : SearchQuery 
{
    Task<TDomain?> GetAsync(Guid id);
    Task<IReadOnlyList<TDomain>> GetListAsync(TSearchQuery query);
    Task<SearchResult<TDomain>> SearchAsync(TSearchQuery query);
    Task<TDomain?> FirstOrDefault(TSearchQuery query);
    Task SaveAsync(TDomain model, bool forceId, bool commit);
    Task<bool> Any(TSearchQuery query);
    Task<int> Count(TSearchQuery query);
    Task Validate(TDomain model);
    Task Delete(Guid id);
}