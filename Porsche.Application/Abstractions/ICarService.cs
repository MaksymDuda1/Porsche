using Porsche.Domain.Dtos;

namespace Porsche.Application.Abstractions;

public interface ICarService
{
    Task<List<CarDto>> GetAllCars();
    Task<CarDto> GetCarById(Guid id);
    Task CreateCar(CreateCarDto createCarDto);
    Task UpdateCar(UpdateCarDto updateCarDto);
    Task UpdatePhoto(UpdatePhotoDto updatePhotoDto);
    Task DeleteCar(Guid id);
}