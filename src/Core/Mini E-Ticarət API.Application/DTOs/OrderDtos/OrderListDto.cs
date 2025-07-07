namespace Mini_E_Ticarət_API.Application.DTOs.OrderDtos;

public record OrderListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int BuyerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = null!;
}
