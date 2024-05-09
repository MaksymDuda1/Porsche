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
        try
        {
            return Ok(await porscheCenterService.GetAllCenters());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PorscheCenterDto>> GetCenterById(Guid id)
    {
        try
        {
            return Ok(await porscheCenterService.GetCenterById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePorscheCenter(CreatePorscheCenterDto request)
    {
        try
        {
            await porscheCenterService.CreateCenter(request);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePorscheCenter(UpdatePorscheCenterDto request)
    {
        try
        {
            await porscheCenterService.UpdateCenter(request);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePorscheCenter(Guid id)
    {
        try
        {
            await porscheCenterService.DeleteCenter(id);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}