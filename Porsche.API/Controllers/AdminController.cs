using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Abstractions;

namespace Porsche.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController(IAdminService adminService) : ControllerBase
{
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> ChangeUserRole(Guid id)
    {
        try
        {
            await adminService.ChangeUserRole(id);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}