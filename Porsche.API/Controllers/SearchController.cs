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
        return Ok(await searchService.CarSearch(request, c =>
            c.Model.Contains(request.SearchQuery, StringComparison.InvariantCultureIgnoreCase)));
    }
    
    [HttpGet("identity-code")]
    public async Task<ActionResult<List<CarDto>>> SearchByIdentityCode([FromQuery] SearchDto request)
    {
        return Ok(await searchService.CarSearch(request,c 
            => c.IdentityCode.Contains(request.SearchQuery, StringComparison.InvariantCultureIgnoreCase)));
    }

    [HttpGet("conditionals")]
    public async Task<IActionResult> SearchByConditionals([FromQuery] SearchByParametersDto request)
    {
        return Ok(await searchService.CarSearch(request));
    }
}