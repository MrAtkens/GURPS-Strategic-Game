using DefaultTemplate.Common;
using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace DefaultTemplate.Api.Common;

public class DefaultController<TService, TDomain, TSearchQuery> : ControllerBase
    where TService : ICrudService<TDomain, TSearchQuery>
    where TDomain : BaseModel
    where TSearchQuery : SearchQuery
{
    protected readonly TService _service;

    public DefaultController(TService service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public Task<TDomain?> GetById(Guid id) => _service.GetAsync(id);

    [HttpPost("all")]
    public Task<IReadOnlyList<TDomain>> GetList([FromBody] TSearchQuery query) => _service.GetListAsync(query);
    
    [HttpPost("search")]
    public Task<SearchResult<TDomain>> Search([FromBody] TSearchQuery query) => _service.SearchAsync(query);
    
    [HttpPost("first")]
    public Task<TDomain?> FirstOrDefault([FromBody] TSearchQuery query) => _service.FirstOrDefault(query);

    [HttpPost("Any")]
    public async Task<SingleValueModel<bool>> Any([FromBody] TSearchQuery query) {
        bool answer = await _service.Any(query);
        return new SingleValueModel<bool>(answer);
    }
    [HttpPost("count")]
    public async Task<SingleValueModel<int>> Count([FromBody] TSearchQuery query)
    {
        int answer = await _service.Count(query);
        return new SingleValueModel<int>(answer);
    }

    [HttpPost]
    public virtual async Task<SingleValueModel<Guid>> Save([FromBody] TDomain model)
    {
        await _service.SaveAsync(model, false, true);
        return new SingleValueModel<Guid>(model.Id);
    }

    [HttpDelete("{id}")]
    public virtual async Task Delete(Guid id)
    {
        await _service.Delete(id);
    }
}