using Mini_E_Ticarət_API.Application.DTOs.FavouriteDtos;
using Mini_E_Ticarət_API.Application.Shared;

namespace Mini_E_Ticarət_API.Application.Abstracts.Services;

public interface IFavouriteService
{
    Task<BaseResponse<List<FavouriteListDto>>> GetAllAsync();
    Task<BaseResponse<string>> CreateAsync(FavouriteCreateDto dto);
    Task<BaseResponse<List<FavouriteListDto>>> GetByUserIdAsync(Guid userId);
    Task<BaseResponse<string>> UpdateAsync(Guid id, FavouriteUpdateDto dto);
    Task<BaseResponse<string>> DeleteAsync(Guid id);

}
