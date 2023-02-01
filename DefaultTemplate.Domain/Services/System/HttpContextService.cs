using DefaultTemplate.Domain.Models.Users;

namespace DefaultTemplate.Domain.Services.System;

public class HttpContextService : IContextService
{
    public User CurrentUser { get; set; } = null!;

    public bool CheckPermision(string permisionId)
    {
        return CurrentUser.Role.Permissions.Any(permision => permision.Id == permisionId);
    }
}