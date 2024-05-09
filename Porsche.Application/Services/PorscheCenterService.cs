using System.Resources;
using AutoMapper;
using Porsche.Application.Abstractions;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Dtos;
using Porsche.Domain.Entities;

namespace Porsche.Application.Services;

public class PorscheCenterService(IFileService fileService, IUnitOfWork unitOfWork, IMapper mapper) : IPorscheCenterService
{
    public async Task<List<PorscheCenterDto>> GetAllCenters()
    {
        var porscheCenters = await unitOfWork.Centers
            .GetAllAsync(p => p.Cars);

        return porscheCenters.Select(mapper.Map<PorscheCenterDto>).ToList();
    }

    public async Task<PorscheCenterDto> GetCenterById(Guid id)
    {
        return mapper.Map<PorscheCenterDto>(await unitOfWork.Centers.GetSingleByConditionAsync(
            c => c.Id == id,
            c => c.Cars));
    }

    public async Task CreateCenter(CreatePorscheCenterDto createPorscheCenterDto)
    {
        var center = mapper.Map<PorscheCenterDto>(createPorscheCenterDto);

        var photo = await fileService.UploadImage(createPorscheCenterDto.PhotoPath);
        center.PhotoPath = photo.FileName;

        await unitOfWork.Centers.InsertAsync(mapper.Map<PorscheCenterEntity>(center));
        await unitOfWork.SaveAsync();
    }

    public async Task UpdateCenter(UpdatePorscheCenterDto updatePorscheCenterDto)
    {
        var center = mapper.Map<PorscheCenterDto>(await unitOfWork.Centers
            .GetSingleByConditionAsync(c => c.Id == updatePorscheCenterDto.Id));

        center.Name = updatePorscheCenterDto.Name;
        center.Address = updatePorscheCenterDto.Address;

        if (updatePorscheCenterDto.PhotoPath != null)
        {
            var photo = await fileService.UploadImage(updatePorscheCenterDto.PhotoPath);
            center.PhotoPath = photo.Path;
        }

        unitOfWork.Centers.Update(mapper.Map<PorscheCenterEntity>(center));
        await unitOfWork.SaveAsync();
    }

    public async Task DeleteCenter(Guid id)
    {
        await unitOfWork.Centers.Delete(id);
        await unitOfWork.SaveAsync();
    }
}