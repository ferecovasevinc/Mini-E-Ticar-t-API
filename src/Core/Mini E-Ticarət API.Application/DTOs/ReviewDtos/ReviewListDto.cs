namespace Mini_E_Ticarət_API.Application.DTOs.ReviewDtos;

public record ReviewListDto
{
    public Guid Id { get; set; }
    public string Comment { get; set; } = null!;
    public int Rating { get; set; }
    public Guid ProductId { get; set; }
    public Guid AppUserId { get; set; }
}
