

namespace DefaultTemplate.Domain.Services.System;
public interface IContextService
{
    CurrentUser CurrentUser { get; set; }
    bool CheckPermision(string permisionId);
}