

namespace E_Commerce.BLL.DTOs;

public class UpdateOrderDto
{
	public string BuyerEmail { get; set; } = string.Empty;
	public ShipmentAddress? ShipToAddress { get; set; }
	public Guid DeliveryMethodId { get; set; }
	public string BasketId { get; set; } = string.Empty;
}
