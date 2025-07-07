namespace Mini_E_Ticarət_API.Application.DTOs.UserDtos;

public record UserAddRoleDto
{
    public Guid UserId { get; set; }
    public List<Guid> RolesId { get; set; }
}
