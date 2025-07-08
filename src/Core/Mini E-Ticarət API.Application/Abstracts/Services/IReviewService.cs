using Mini_E_Ticarət_API.Application.DTOs.ReviewDtos;
using Mini_E_Ticarət_API.Application.Shared;

namespace Mini_E_Ticarət_API.Application.Abstracts.Services;

public interface IReviewService
{
    Task<BaseResponse<string>> CreateAsync(ReviewCreateDto dto, Guid userId);
    Task<BaseResponse<string>> UpdateAsync(ReviewUpdateDto dto, Guid userId);
    Task<BaseResponse<string>> DeleteAsync(Guid id, Guid userId);
    Task<BaseResponse<List<ReviewListDto>>> GetByProductIdAsync(Guid productId);
}
