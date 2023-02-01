using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Services.Common;

public interface IEnumRepository<TEnum> where TEnum : EnumModel
{
    public Task<IReadOnlyList<TEnum>> GetAllAsync();
    public Task Save(TEnum model);
}