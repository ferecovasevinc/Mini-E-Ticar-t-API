namespace Mini_E_Ticarət_API.Application.DTOs.ImageDtos;

public record ImageCreateDto
{
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }
    public Guid ProductId { get; set; }
}
