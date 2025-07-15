using AutoMapper;
using Mini_E_Ticarət_API.Application.DTOs.OrderDtos;
using Mini_E_Ticarət_API.Application.DTOs.OrderProductDtos;
using Mini_E_Ticarət_API.Domain.Entities;

namespace Mini_E_Ticarət_API.Application.MappingProfiles;

public class OrderProductProfile : Profile
{
    public OrderProductProfile()
    {
        CreateMap<OrderProduct, OrderProductListDto>();
        CreateMap<OrderProduct, OrderProductDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        CreateMap<OrderProductCreateDto, OrderProduct>();
        CreateMap<OrderProductUpdateDto, OrderProduct>();
    }
}
