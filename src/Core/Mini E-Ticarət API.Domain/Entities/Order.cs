namespace Mini_E_Ticarət_API.Domain.Entities;

public class Order : BaseEntity
{
    public string Name { get; set; }
    public int BuyerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = "Pending";

    public ICollection<OrderProduct> OrderProducts { get; set; }
}
