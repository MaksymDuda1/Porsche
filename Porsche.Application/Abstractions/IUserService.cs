using Porsche.Domain.Dtos;

namespace Porsche.Application.Abstractions;

public interface IUserService
{
    Task<List<UserDto>> GetAll();
    Task AddCarToSaved(UserCarDto userCarDto);
    Task<bool> IsInFavorite(UserCarDto userCarDto);
    Task<List<CarDto>> GetSavedCars(Guid id);
    Task DeleteUser(Guid id);
    Task Order(OrderDto orderDto);
}