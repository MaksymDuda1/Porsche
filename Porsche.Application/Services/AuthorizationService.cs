using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Porsche.Application.Abstractions;
using Porsche.Domain.Dtos;
using Porsche.Domain.Entities;

namespace Porsche.Application.Services;

public class AuthorizationService(ITokenService tokenService, 
    UserManager<UserEntity> userManager,
    SignInManager<UserEntity> signInManager) : IAuthorizationService
{
    public async Task<string> LoginUser(LoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);

        if (user is null)
            throw new Exception("User doesn't exist");

        var result = await signInManager
            .PasswordSignInAsync(user, loginDto.Password, false, false);

        if (!result.Succeeded)
            throw new Exception("Incorrect login or password");

        var roles = await userManager.GetRolesAsync(user);
        
        var claims = await userManager.GetClaimsAsync(user);
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()));
        tokenService.AddRolesToClaims(claims, roles);
        var token = tokenService.CreateToken(claims);

        await userManager.UpdateAsync(user);

        return token;
    }
    public async Task<string> RegisterUser(RegistrationDto registrationDto)
    {
        string userName = registrationDto.Email.Substring(0, registrationDto.Email.IndexOf('@'));

        var user = new UserEntity()
        {
            Id = Guid.NewGuid(),
            UserName = userName,
            Email = registrationDto.Email,
            FirstName = registrationDto.FirstName,
            SecondName = registrationDto.SecondName
        };

        var result = await userManager.CreateAsync(user, registrationDto.Password);

        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);

        await userManager.AddToRoleAsync(user, "USER");
        
        var roles = await userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, user.Id.ToString())
        };
        
        tokenService.AddRolesToClaims(authClaims, roles);

        var token = tokenService.CreateToken(authClaims);

        return token;
    }
    

}