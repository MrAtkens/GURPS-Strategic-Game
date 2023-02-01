using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Services.Common;

public class EnumService<TEnum> : IEnumService<TEnum> where TEnum : EnumModel
{
    private readonly IEnumRepository<TEnum> _repository;

    public EnumService(IEnumRepository<TEnum> repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<TEnum>> GetAllAsync() => _repository.GetAllAsync();
}