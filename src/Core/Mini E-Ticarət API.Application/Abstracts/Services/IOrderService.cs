using Mini_E_Ticarət_API.Application.DTOs.OrderDtos;
using Mini_E_Ticarət_API.Application.Shared;

namespace Mini_E_Ticarət_API.Application.Abstracts.Services;

public interface IOrderService
{
    Task<BaseResponse<string>> CreateAsync(OrderCreateDto dto);
    Task<BaseResponse<List<OrderListDto>>> GetAllAsync();
    Task<BaseResponse<OrderListDto>> GetByIdAsync(Guid id);
    Task<BaseResponse<string>> UpdateAsync(OrderUpdateDto dto);
    Task<BaseResponse<string>> DeleteAsync(Guid id);
}
