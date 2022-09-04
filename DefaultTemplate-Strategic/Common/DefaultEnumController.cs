using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace DefaultTemplate.Common;

public class DefaultEnumController<TService, TEnum> : ControllerBase
    where TEnum : EnumModel
    where TService : IEnumService<TEnum>
{
    private readonly TService _service;

    public DefaultEnumController(TService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public Task<IReadOnlyList<TEnum>> GetAll() => _service.GetAllAsync();
}