using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Abstractions;
using Porsche.Domain.Dtos;

namespace Porsche.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthorizationController(IAuthorizationService authorizationService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginDto request)
    {
        return Ok(await authorizationService.LoginUser(request));
    }

    [HttpPost("registration")]
    public async Task<ActionResult<string>> Registration(RegistrationDto request)
    {
        return Ok(await authorizationService.RegisterUser(request));
    }

}