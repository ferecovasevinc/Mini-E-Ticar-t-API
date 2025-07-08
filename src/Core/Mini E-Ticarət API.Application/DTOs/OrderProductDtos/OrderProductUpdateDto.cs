namespace Mini_E_Ticarət_API.Application.DTOs.OrderProductDtos;

public record OrderProductUpdateDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
