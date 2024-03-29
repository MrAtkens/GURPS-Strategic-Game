﻿using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DefaultTemplate.Domain.Models.Bussineses;
using DefaultTemplate.Domain.Models.Users;
using DefaultTemplate.Domain.Models.Waiters;
using DefaultTemplate.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DefaultTemplate.Domain.Services.ContextService;

public class HttpContextService : IContextService
{
    private readonly IOptions<JwtOptions> _options;
    public User? CurrentUser { get; set; } = null;
    public Waiter? CurrentWaiter { get; set; }
    public Business? CurrentBussiness { get; set; }
    public long RegionId { get; set; }
    public bool isBussiness { get; set; }

    public HttpContextService(IOptions<JwtOptions> options)
    {
        _options = options;
    }

    public bool CheckPermission(string permissionId)
    {
        return CurrentUser.Role.Permissions.Any(permission => permission.Id == permissionId);
    }

    public string? ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_options.Value.Key);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var mail = jwtToken.Claims.First(x => x.Type == "Mail").Value;

        return mail;
    }
}