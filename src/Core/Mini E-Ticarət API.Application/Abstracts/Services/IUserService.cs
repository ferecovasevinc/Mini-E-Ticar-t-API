using Mini_E_Ticarət_API.Application.DTOs.UserDtos;
using Mini_E_Ticarət_API.Application.Shared;

namespace Mini_E_Ticarət_API.Application.Abstracts.Services;

public interface IUserService
{
    Task<BaseResponse<string>> Register(UserRegisterDto dto);
    Task<BaseResponse<TokenResponse>> Login(UserLoginDto dto);
    Task<BaseResponse<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request);
    Task<BaseResponse<string>> AddRole(UserAddRoleDto dto);
    Task<BaseResponse<string>> ConfirmEmail(Guid userId, string token);

}
