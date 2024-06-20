using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Abstractions;
using Porsche.Domain.Dtos;

namespace Porsche.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController(IAdminService adminService) : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> ChangeUserRole([FromBody] ChangeRoleDto request)
    {
        await adminService.ChangeUserRole(request);
        return Ok();
    }
}