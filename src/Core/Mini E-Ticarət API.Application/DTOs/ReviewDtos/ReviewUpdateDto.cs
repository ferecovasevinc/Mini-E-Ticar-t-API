namespace Mini_E_Ticarət_API.Application.DTOs.ReviewDtos;

public record ReviewUpdateDto
{
    public Guid Id { get; set; }
    public string? Comment { get; set; }
    public int? Rating { get; set; }
}
