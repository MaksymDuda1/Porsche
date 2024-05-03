using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Porsche.Application.Abstractions;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Dtos;
using Porsche.Domain.Entities;

namespace Porsche.Application.Services;

public class UserService(IUnitOfWork unitOfWork,
    IMapper mapper) : IUserService
{
    public async Task<List<UserDto>> GetAll()
    {
        var users = await unitOfWork.Users.GetAllAsync(
            u => u.SavedCars);
        
        if (users.IsNullOrEmpty())
            throw new Exception("List of users is empty");
        
        var usersDto = users.Select(mapper.Map<UserDto>).ToList();
        return usersDto;
    }

    public async Task AddCarToSaved(UserCarDto userCarDto)
    {
        var isInFavorite = await IsInFavorite(userCarDto);

        if (isInFavorite)
            unitOfWork.UsersCars.Delete(mapper.Map<UserCarEntity>(userCarDto));
        else
            await unitOfWork.UsersCars.InsertAsync(
                mapper.Map<UserCarEntity>(userCarDto));
        
        await unitOfWork.SaveAsync();
    }

    public async Task<bool> IsInFavorite(UserCarDto userCarDto)
    {
        var existingAssociation = await unitOfWork.UsersCars.GetSingleByConditionAsync(
            uc => uc.UserId == userCarDto.UserId &&
                  uc.CarId == userCarDto.CarId);

        return existingAssociation != null ? true : false;
    }

    public async Task<List<CarDto>> GetSavedCars(Guid id)
    {
        var cars = await unitOfWork.Cars.GetByConditionsAsync(
            c => c.Users.Any(u => u.Id == id));

        return cars.Select(mapper.Map<CarDto>).ToList();
    }

    public async Task DeleteUser(Guid id)
    {
        await unitOfWork.Users.Delete(id);
        await unitOfWork.SaveAsync();
    }
}