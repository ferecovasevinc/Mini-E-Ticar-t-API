using AutoMapper;
using Mini_E_Ticarət_API.Application.DTOs.OrderDtos;
using Mini_E_Ticarət_API.Domain.Entities;

namespace Mini_E_Ticarət_API.Application.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderListDto>();
        CreateMap<Order, OrderDetailDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts));
        CreateMap<OrderCreateDto, Order>();
        CreateMap<OrderUpdateDto, Order>();
    }
}
