namespace Mini_E_Ticarət_API.Application.DTOs.OrderProductDtos;

public record OrderProductCreateDto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
