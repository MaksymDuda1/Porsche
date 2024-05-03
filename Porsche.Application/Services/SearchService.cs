using AutoMapper;
using Porsche.Application.Abstractions;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Dtos;
using Porsche.Domain.Entities;

namespace Porsche.Application.Services;

public class SearchService(IUnitOfWork unitOfWork, IMapper mapper) : ISearchService
{
    public async Task<List<CarDto>> CarSearch(SearchDto searchDto, Func<CarEntity, bool> searchPredicate)
    {
        var cars = await unitOfWork.Cars
            .GetAllAsync(c => c.PorscheCenter);

        var matchingCars = mapper.Map<List<CarDto>>(cars.Where(searchPredicate));

        return matchingCars;
    }
    
    public async Task<List<CarDto>> CarSearch(SearchByParametersDto searchDto)
    {
        var cars = mapper.Map<List<CarDto>>(await unitOfWork.Cars
            .GetAllAsync(c => c.PorscheCenter));

        var query = cars.AsQueryable();
        
        if (searchDto.Model != null)
            query = query.Where(c => c.Model == searchDto.Model);
        
        if (searchDto.BodyType.Length != 0) 
            query = query.Where(c => searchDto.BodyType.Contains(c.BodyType));
    
        if (searchDto.Colors.Length != 0) 
            query = query.Where(c => searchDto.Colors.Contains(c.Color));
        
        if (searchDto.MinYearOfRelease != 0) 
            query = query.Where(c => c.YearOfEdition >= searchDto.MinYearOfRelease);
        
        if (searchDto.MaxYearOfRelease != 0) 
            query = query.Where(c => c.YearOfEdition <= searchDto.MaxYearOfRelease);
        
        if (searchDto.MinPrice != 0) 
            query = query.Where(c => c.Price >= searchDto.MinPrice);
        
        if (searchDto.MaxPrice != 0) 
            query = query.Where(c => c.Price <= searchDto.MaxPrice);
        
        if (searchDto.Engine.Length != 0) 
            query = query.Where(c => searchDto.Engine.Contains(c.Engine));
        
        if (searchDto.PorscheCenter.Length != 0) 
            query = query.Where(c => searchDto.PorscheCenter.Contains(c.PorscheCenter.Name));

        return query.ToList();
    }
}