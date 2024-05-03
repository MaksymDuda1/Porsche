using Microsoft.AspNetCore.Identity;
using Porsche.Application.Abstractions;
using Porsche.Domain.Entities;

namespace Porsche.Application.Services;

public class AdminService(UserManager<UserEntity> _userManager) : IAdminService
{
    public async Task ChangeUserRole(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user == null)
            throw new Exception("User does not exist");

        var claims = await _userManager.GetClaimsAsync(user);
        var currentRoles = await _userManager.GetRolesAsync(user);

        if (currentRoles.Contains("Admin"))
        {
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            await _userManager.AddToRoleAsync(user, "User");
        }
        else
        {
            await _userManager.RemoveFromRoleAsync(user, "User");
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        /*await _userManager.ReplaceClaimAsync(user, claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Role),
            new Claim(JwtClaimTypes.Role, role.Name));*/
        await _userManager.UpdateAsync(user);
    }
}