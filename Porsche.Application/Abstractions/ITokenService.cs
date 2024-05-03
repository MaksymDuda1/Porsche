using System.Security.Claims;

namespace Porsche.Application.Abstractions;

public interface ITokenService
{
    string CreateToken(IList<Claim> claims);
    void AddRolesToClaims(IList<Claim> claims, IList<string> roles);
}