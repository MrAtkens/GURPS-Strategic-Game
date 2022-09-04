namespace DefaultTemplate.Domain.Services.System;

public class HttpContextService : IContextService
{
    public CurrentUser CurrentUser { get; set; } = null!;

    public bool CheckPermision(string permisionId)
    {
        if (CurrentUser.Id == Domain.NatPersons.SysUser.Id)
            return true;
        return CurrentUser.Permissions.Any(permision => permision.Id == permisionId);
    }
}