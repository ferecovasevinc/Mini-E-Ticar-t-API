namespace Mini_E_Ticarət_API.Application.DTOs.UserDtos;

public record UserRegisterDto
{
    public string Fullname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
