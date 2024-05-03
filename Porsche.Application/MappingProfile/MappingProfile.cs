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
        
        CreateMap<CarEntity, CarDto>().ReverseMap()
            .ForMember(c => c.Photos,
                opt => opt.Ignore())
            .ForMember(c => c.PorscheCenterId,
                opt => opt.Ignore())
            .ForMember(c => c.PorscheCenter, 
                opt => opt.Ignore());
        
        CreateMap<CreateCarDto, CarDto>().ReverseMap()
            .ForMember(c => c.Photos, 
                opt => opt.Ignore());

        CreateMap<PorscheCenterDto, PorscheCenterEntity>().ReverseMap();
        CreateMap<CreatePorscheCenterDto, PorscheCenterDto>().ReverseMap()
            .ForMember(c => c.Photo,
                opt => opt.Ignore());

        CreateMap<PhotoDto, PhotoEntity>().ReverseMap();
        CreateMap<SearchModel, SearchByParametersDto>();
    }
}