using Mini_E_Ticarət_API.Application.DTOs.RoleDtos;
using Mini_E_Ticarət_API.Application.Shared;

namespace Mini_E_Ticarət_API.Application.Abstracts.Services;

public interface IRoleService
{
    Task<BaseResponse<string?>> CreateRole(RoleCreateDto dto);
}
