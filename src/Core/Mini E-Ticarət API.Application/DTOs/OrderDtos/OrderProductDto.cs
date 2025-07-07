namespace Mini_E_Ticarət_API.Application.DTOs.OrderDtos;

public record OrderProductDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
