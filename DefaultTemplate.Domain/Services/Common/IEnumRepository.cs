using DefaultTemplate.Domain.Models;

namespace DefaultTemplate.Domain.Services.Common;

public interface IEnumRepository<TEnum> where TEnum : EnumModel
{
    public Task<IReadOnlyList<TEnum>> GetAllAsync();
    public Task Save(TEnum model);
}