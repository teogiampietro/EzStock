using EzStock.Service.Auth.Command;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EzStock.Service.Auth.CommandHandler;

public class TokenCommandHandler : IRequestHandler<TokenCommand, string>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _config;
    public TokenCommandHandler(UserManager<IdentityUser> userManager, IConfiguration config)
    {
        _userManager = userManager;
        _config = config;
    }

    public async Task<string> Handle(TokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            throw new Exception("This would be a FordibbenAcessException");

        var roles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim("sid", user.Id),
            new Claim("name", user.UserName),
        };

        foreach (var role in roles)
            claims.Add(new Claim("role", role));

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "DefaultSecret"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        return jwt;
    }
}
