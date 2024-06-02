
namespace E_Commerce.BLL.DTOs;

public class CreateOrderDto
{
	public string BuyerEmail { get; set; } = string.Empty;
    public string BasketId { get; set; } = string.Empty;
    public Guid DeliveryMethodId { get; set; }
    public ShipmentAddress? ShipmentAddress { get; set; }
}
