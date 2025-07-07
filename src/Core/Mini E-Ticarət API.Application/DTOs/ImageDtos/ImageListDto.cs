namespace Mini_E_Ticarət_API.Application.DTOs.ImageDtos;

public record ImageListDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }
    public Guid ProductId { get; set; }
}
