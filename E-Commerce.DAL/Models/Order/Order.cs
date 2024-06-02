namespace E_Commerce.DAL.Models;

public class Order : BaseModel<Guid>
{
	public string BuyerEmail { get; set; } = string.Empty;
	public DateTime OrderDate { get; set; } = DateTime.UtcNow;
	public ShipmentAddress? ShipToAddress { get; set; }


	[ForeignKey(nameof(DeliveryMethod))]
	public Guid DeliveryMethodId { get; set; }
	public DeliveryMethod? DeliveryMethod { get; set; }

	public ICollection<OrderItem>? OrderItems { get; set; }
	public decimal TotalPrice { get; set; }
	public OrderStatus Status { get; set; } = OrderStatus.Pending;

	public string? PaymentIntentId { get; set; }

}
