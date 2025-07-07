namespace Mini_E_Ticarət_API.Application.DTOs.OrderDtos;

public record OrderUpdateDto
{
    public Guid Id { get; set; }
    public string? Status { get; set; }
}
