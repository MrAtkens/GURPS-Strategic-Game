using DefaultTemplate.Domain.Models.Users;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.Users;

public interface IUserRepository : ICrudRepository<User, UserQuery>
{
    bool PasswordVerify(string password, long userId);
}