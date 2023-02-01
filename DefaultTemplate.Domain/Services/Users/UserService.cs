using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DefaultTemplate.Common.Enums;
using DefaultTemplate.Common.Exceptions;
using DefaultTemplate.Domain.Models.Users;
using DefaultTemplate.Domain.Services.Common;
using FluentValidation;
using MGZNew.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DefaultTemplate.Domain.Services.Users;

public class UserService: BaseService<User, UserQuery>, IUserService
{
    private readonly IOptions<JwtOptions> _options;
    protected override AbstractValidator<User>? Validator => new UserValidator();
    private IUserRepository _userRepository;

    public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IOptions<JwtOptions> options) : base(repository, unitOfWork)
    {
        _userRepository = repository;
        _options = options;
    }


    public async Task<SingleValueModel<string>> Authorize(AuthorizeDto authorizeDto)
    {
        var user = await _repository.FirstOrDefault(new UserQuery() { Mail = authorizeDto.Mail });
        if (user is null)
            throw new ExecutionResultException(DefaultResult.IncorrectData, $"Проверьте вашу почту и пароль на корректность");
        if (_userRepository.PasswordVerify(authorizeDto.Password, user.Id) == false)
            throw new ExecutionResultException(DefaultResult.IncorrectData, $"Проверьте вашу почту и пароль на корректность");
        return new SingleValueModel<string>(GenerateToken(user));
    }
    
    
    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_options.Value.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _options.Value.Issuer,
            Audience = _options.Value.Audience,
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}