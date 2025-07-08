using Mini_E_Ticarət_API.Application.DTOs.OrderProductDtos;
using Mini_E_Ticarət_API.Application.Shared;

namespace Mini_E_Ticarət_API.Application.Abstracts.Services;

public interface IOrderProductService
{
    Task<BaseResponse<string>> CreateAsync(OrderProductCreateDto dto);
    Task<BaseResponse<string>> UpdateAsync(OrderProductUpdateDto dto);
    Task<BaseResponse<string>> DeleteAsync(Guid id);
    Task<BaseResponse<List<OrderProductListDto>>> GetAllAsync();
    Task<BaseResponse<OrderProductListDto>> GetByIdAsync(Guid id);
}
