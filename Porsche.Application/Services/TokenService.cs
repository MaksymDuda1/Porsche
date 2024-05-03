using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Porsche.Application.Abstractions;

namespace Porsche.Application.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string CreateToken(IList<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecret = configuration["jwtSecret"]!;
        var key = Encoding.ASCII.GetBytes(jwtSecret);
        var identity = new ClaimsIdentity(claims);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }

    public void AddRolesToClaims(IList<Claim> claims, IList<string> roles)
    {
        foreach (var role in roles)
        {
            var roleClaims = new Claim(ClaimTypes.Role, role);
            claims.Add(roleClaims);
        }
    }
}