using AutoMapper;
using Mini_E_Ticarət_API.Application.DTOs.ImageDtos;
using Mini_E_Ticarət_API.Domain.Entities;

namespace Mini_E_Ticarət_API.Application.MappingProfiles;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        CreateMap<Image, ImageListDto>();
        CreateMap<ImageCreateDto, Image>();
        CreateMap<ImageUpdateDto, Image>();
    }
}
