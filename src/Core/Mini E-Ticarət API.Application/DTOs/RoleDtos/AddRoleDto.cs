namespace Mini_E_Ticarət_API.Application.DTOs.RoleDtos;

public class AddRoleDto
{
    public Guid AppUserId { get; set; }
    public string RoleName { get; set; } = null!;
}
