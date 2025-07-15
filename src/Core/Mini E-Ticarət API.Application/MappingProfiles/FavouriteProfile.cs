using AutoMapper;
using Mini_E_Ticarət_API.Application.DTOs.FavouriteDtos;
using Mini_E_Ticarət_API.Domain.Entities;

namespace Mini_E_Ticarət_API.Application.MappingProfiles;

public class FavouriteProfile : Profile
{
    public FavouriteProfile()
    {
        CreateMap<Favourite, FavouriteListDto>();
        CreateMap<FavouriteCreateDto, Favourite>();
        CreateMap<FavouriteUpdateDto, Favourite>();
    }
}
