using DefaultTemplate.Common;
using DefaultTemplate.Domain.DTOs;
using DefaultTemplate.Domain.Models.Users;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.Users;

public interface IUserService : ICrudService<User, UserQuery>
{ 
    Task<SingleValueModel<string>> Authorize(AuthorizeDto authorizeDto);
}