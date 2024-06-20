using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Abstractions;
using Porsche.Domain.Dtos;

namespace Porsche.Controllers;

[ApiController]
[Route("api/centers")]
public class PorscheCenterController(IPorscheCenterService porscheCenterService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAllCenters()
    {
        return Ok(await porscheCenterService.GetAllCenters());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PorscheCenterDto>> GetCenterById(Guid id)
    {
        return Ok(await porscheCenterService.GetCenterById(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreatePorscheCenter(CreatePorscheCenterDto request)
    {
        await porscheCenterService.CreateCenter(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePorscheCenter(UpdatePorscheCenterDto request)
    {
        await porscheCenterService.UpdateCenter(request);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePorscheCenter(Guid id)
    {
        await porscheCenterService.DeleteCenter(id);
        return Ok();
    }
}