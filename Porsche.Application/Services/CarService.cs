using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Porsche.Application.Abstractions;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Dtos;
using Porsche.Domain.Entities;

namespace Porsche.Application.Services;

public class CarService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService) : ICarService
{
    public async Task<List<CarDto>> GetAllCars()
    {
        var cars = await unitOfWork.Cars.GetAllAsync(
            c => c.PorscheCenter,
            c => c.Photos,
            c => c.Users);
            
        return cars.Select(mapper.Map<CarDto>).ToList();
    }

    public async Task<CarDto> GetCarById(Guid id)
    {
        var car = await unitOfWork.Cars.GetSingleByConditionAsync(
            c => c.Id == id,
            c => c.Photos,
            c => c.PorscheCenter);

        if (car == null)
            throw new Exception("Car doesn't found");

        return mapper.Map<CarDto>(car);
    }

    public async Task CreateCar(CreateCarDto createCarDto)
    {
        var carDto = new CarDto()
        {
            IdentityCode = createCarDto.IdentityCode,
            Model = createCarDto.Model,
            BodyType = createCarDto.BodyType,
            Color = createCarDto.Color,
            FuelConsumption = createCarDto.FuelConsumption,
            YearOfEdition = createCarDto.YearOfEdition,
            Engine = createCarDto.Engine,
            Price = createCarDto.Price
        };

        var porscheCenter = await unitOfWork.Centers
            .GetSingleByConditionAsync(c => c.Id == createCarDto.PorscheCenterId);

        if (porscheCenter == null)
            throw new Exception($"Porsche Center with ID {createCarDto.PorscheCenterId} not found.");

        carDto.PorscheCenterId = porscheCenter.Id;

        var carEntity = mapper.Map<CarEntity>(carDto);

        if (createCarDto.Photos != null)
        {
            foreach (var photo in createCarDto.Photos)
            {
                var photoDto = await fileService.UploadImage(photo);
                carEntity.Photos.Add(mapper.Map<PhotoEntity>(photoDto));
            }
        }        

        await unitOfWork.Cars.InsertAsync(carEntity);
        await unitOfWork.SaveAsync();
    }


    public async Task UpdateCar(UpdateCarDto updateCarDto)
    {
        var car = mapper.Map<CarDto>(await unitOfWork.Cars
            .GetSingleByConditionAsync(c => c.Id == updateCarDto.Id));

        car.Model = updateCarDto.Model;
        car.YearOfEdition = updateCarDto.YearOfEdition;
        car.BodyType = updateCarDto.BodyType;
        car.Color = updateCarDto.Color;
        car.Engine = updateCarDto.Engine;
        car.FuelConsumption = updateCarDto.FuelConsumption;
        car.Price = updateCarDto.Price;
        car.Status = updateCarDto.Status;

        var porscheCenter = mapper.Map<PorscheCenterDto>(await unitOfWork.Centers
            .GetSingleByConditionAsync(c => c.Id == updateCarDto.PorscheCenterId));

        if (porscheCenter != null)
            car.PorscheCenter = porscheCenter;

        unitOfWork.Cars.Update(mapper.Map<CarEntity>(car));
        await unitOfWork.SaveAsync();
    }

    public async Task UpdatePhoto(UpdatePhotoDto updatePhotoDto)
    {
        var car = await unitOfWork.Cars
            .GetSingleByConditionAsync(c => c.Id == updatePhotoDto.CarId);
       
        var photoToUpdate = car.Photos
            .FirstOrDefault(p => p.FileName == updatePhotoDto.OldPhotoName);
        
        if (photoToUpdate != null)
        {
        
            var photo = await fileService.UploadImage(updatePhotoDto.NewPhoto);

        
            photoToUpdate.FileName = photo.FileName;
            photoToUpdate.Path = photo.Path;
        }
        
        await unitOfWork.SaveAsync();
    }

    public async Task DeleteCar(Guid id)
    {
        await unitOfWork.Cars.Delete(id);
        await unitOfWork.SaveAsync();
    }
}