using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Abstractions;
using Porsche.Domain.Dtos;

namespace Porsche.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController(ISearchService searchService) : ControllerBase
{
    [HttpGet("model")]
    public async Task<ActionResult<List<CarDto>>> SearchByModel([FromQuery] SearchDto request)
    {
        try
        {
            return Ok(await searchService.CarSearch(request, c =>
                c.Model.Contains(request.SearchQuery, StringComparison.InvariantCultureIgnoreCase)));
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("identity-code")]
    public async Task<ActionResult<List<CarDto>>> SearchByIdentityCode([FromQuery] SearchDto request)
    {
        try
        {
            return Ok(await searchService.CarSearch(request,c
                => c.IdentityCode.Contains(request.SearchQuery, StringComparison.InvariantCultureIgnoreCase)));
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("conditionals")]
    public async Task<IActionResult> SearchByConditionals([FromQuery] SearchByParametersDto request)
    {
        try
        {
            return Ok(await searchService.CarSearch(request));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}