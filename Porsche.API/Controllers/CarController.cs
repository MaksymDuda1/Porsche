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
        try
        {
            return Ok(await carService.GetCarById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar([FromForm] CreateCarDto request)
    {
        try
        {
            await carService.CreateCar(request);
                
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarDto request)
    {
        try
        {
            await carService.UpdateCar(request);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("update-photo")]
    public async Task<IActionResult> UpdateCarPhoto(UpdatePhotoDto request)
    {
        try
        {
            await carService.UpdatePhoto(request);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        try
        {
            await carService.DeleteCar(id);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}