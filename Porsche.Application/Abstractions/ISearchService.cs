using Porsche.Domain.Dtos;
using Porsche.Domain.Entities;

namespace Porsche.Application.Abstractions;

public interface ISearchService
{
    Task<List<CarDto>> CarSearch(SearchDto searchDto, Func<CarEntity, bool> searchPredicate);
    Task<List<CarDto>> CarSearch(SearchByParametersDto searchDto);
}