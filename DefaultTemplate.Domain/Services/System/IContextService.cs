using DefaultTemplate.Domain.Models.Users;

namespace DefaultTemplate.Domain.Services.System;
public interface IContextService
{
    User CurrentUser { get; set; }
    bool CheckPermision(string permisionId);
}