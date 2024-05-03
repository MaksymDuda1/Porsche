using Porsche.Domain.Dtos;

namespace Porsche.Application.Abstractions;

public interface IPorscheCenterService
{
    Task<List<PorscheCenterDto>> GetAllCenters();
    Task<PorscheCenterDto> GetCenterById(Guid id);
    Task CreateCenter(CreatePorscheCenterDto createPorscheCenterDto);
    Task UpdateCenter(UpdatePorscheCenterDto updatePorscheCenterDto);
    Task DeleteCenter(Guid id);
}