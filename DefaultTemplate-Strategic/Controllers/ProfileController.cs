using DefaultTemplate.Api.Common;
using DefaultTemplate.Common;
using DefaultTemplate.Domain.DTOs;
using DefaultTemplate.Domain.Models.Users;
using DefaultTemplate.Domain.Services.ContextService;
using DefaultTemplate.Domain.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefaultTemplate_Strategic.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class ProfileController
{
    private IContextService _contextService;
    private IUserService _userService;
    
    public ProfileController(IUserService userService, IContextService contextService)
    {
        _contextService = contextService;
        _userService = userService;
    }
    
    [HttpGet]
    public User GetCurrentUser()
    {
        return _contextService.CurrentUser;
    }
    
    [HttpGet("{id}")]
    public bool PermissionCheck(string id)
    {
        return _contextService.CheckPermission(id);
    }

    [HttpPost("auth")]
    public async Task<SingleValueModel<string>> Authorize([FromBody] AuthorizeDto authorizeDto) => await _userService.Authorize(authorizeDto);
}