using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Abstractions;
using Porsche.Domain.Dtos;

namespace Porsche.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAllUsers()
    {
        return Ok(await userService.GetAll());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<List<CarDto>>> GetSavedCars(Guid id)
    {
        return Ok(await userService.GetSavedCars(id));
    }

    [HttpGet("favorite")]
    public async Task<ActionResult<bool>> IsInFavorite([FromQuery] UserCarDto request)
    {
        return Ok(await userService.IsInFavorite(request));
    }

    [HttpPut]
    public async Task<IActionResult> AddCarToSaved(UserCarDto request)
    {
        await userService.AddCarToSaved(request);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await userService.DeleteUser(id);
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Order(OrderDto request)
    {
        await userService.Order(request);
        return Ok();
    }
    
}