namespace Mini_E_Ticarət_API.Application.DTOs.ImageDtos;

public record ImageUpdateDto
{
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }
}
