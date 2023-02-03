namespace DefaultTemplate.Domain.Services.Common;

public interface IEnumService<TDomain>
{
    public Task<IReadOnlyList<TDomain>> GetAllAsync();
}