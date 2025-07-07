namespace Mini_E_Ticarət_API.Application.DTOs.CategoryDtos;

public record CategoryUpdateDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}
