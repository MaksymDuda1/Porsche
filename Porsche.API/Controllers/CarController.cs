using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Abstractions;
using Porsche.Domain.Dtos;

namespace Porsche.Controllers;

[ApiController]
[Route("api/cars")]
public class CarController(ICarService carService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        try
        {
            return Ok(await carService.GetAllCars());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCarById(Guid id)
    {
        return Ok(await carService.GetCarById(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar([FromForm] CreateCarDto request)
    {
        await carService.CreateCar(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarDto request)
    {
        await carService.UpdateCar(request);
        return Ok();
    }

    [HttpPut("update-photo")]
    public async Task<IActionResult> UpdateCarPhoto(UpdatePhotoDto request)
    {
        await carService.UpdatePhoto(request);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        await carService.DeleteCar(id);
        return Ok();
    }
}