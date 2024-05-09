using AutoMapper;
using Porsche.Application.Models;
using Porsche.Domain.Dtos;
using Porsche.Domain.Entities;

namespace Porsche.Application.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, UserDto>().ReverseMap();
        CreateMap<UserCarEntity, UserCarDto>().ReverseMap();

        CreateMap<CarEntity, CarDto>().ReverseMap();

        CreateMap<CreateCarDto, CarDto>().ReverseMap()
            .ForMember(c => c.Photos,
                opt => opt.Ignore());
           

        CreateMap<PorscheCenterDto, PorscheCenterEntity>().ReverseMap();
        CreateMap<CreatePorscheCenterDto, PorscheCenterDto>().ReverseMap()
            .ForMember(c => c.PhotoPath,
                opt => opt.Ignore());

        CreateMap<PhotoDto, PhotoEntity>().ReverseMap();
        CreateMap<SearchModel, SearchByParametersDto>();
    }
}