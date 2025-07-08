namespace Mini_E_Ticarət_API.Application.DTOs.ReviewDtos;

public record ReviewCreateDto
{
    public string Comment { get; set; } = null!;
    public int Rating { get; set; }
    public Guid ProductId { get; set; }
}
