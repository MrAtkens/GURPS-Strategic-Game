using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Users;
using DefaultTemplate.Domain.Services.ContextService;
using DefaultTemplate.Domain.Services.Users;
using MGZNew.Domain.Options;
using Microsoft.Extensions.Options;

namespace DefaultTemplate.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository<User, UserEntity, UserQuery>, IUserRepository
{
    private readonly IOptions<JwtOptions> _options;

    public UserRepository(DefaultContext context, IMapper mapper, IContextService contextService, IOptions<JwtOptions> options) : base(context, mapper, contextService)
    {
        _options = options;
    }
    protected override void Update(UserEntity entity, User model)
    {
        entity.RoleId = model.RoleId;
        entity.LoginMail = model.LoginMail;
        entity.Password =  BCrypt.Net.BCrypt.HashPassword(model.Password);
    }

    protected override IQueryable<UserEntity> Search(IQueryable<UserEntity> dbQuery, UserQuery query)
    {
        if (query.Ids?.Any() == true)
            dbQuery = dbQuery.Where(x => query.Ids.Contains(x.Id));
        if (query.ExcludeIds?.Any() == true)
            dbQuery = dbQuery.Where(x => !query.ExcludeIds.Contains(x.Id));
        if (!string.IsNullOrWhiteSpace(query.Mail))
            dbQuery = dbQuery.Where(x => x.LoginMail == query.Mail);
        
        return dbQuery;
    }

    public bool PasswordVerify(string password, Guid userId)
    {
        var user = _dbSet.FirstOrDefault(x => x.Id == userId);
        return BCrypt.Net.BCrypt.Verify(password, user?.Password);
    }

}