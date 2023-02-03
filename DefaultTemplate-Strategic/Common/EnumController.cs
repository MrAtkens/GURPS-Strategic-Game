using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace DefaultTemplate_Strategic.Common;

public class EnumController<TService, TEnum> : ControllerBase
    where TEnum : EnumModel
    where TService : IEnumService<TEnum>
{
    private readonly TService _service;

    public EnumController(TService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public Task<IReadOnlyList<TEnum>> GetAll() => _service.GetAllAsync();
}