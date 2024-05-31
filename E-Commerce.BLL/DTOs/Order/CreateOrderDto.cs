
namespace E_Commerce.BLL.DTOs;

public class CreateOrderDto
{
	public string BuyerEmail { get; set; } = string.Empty;
    public string BasketId { get; set; } = string.Empty;
    public Guid ShipmentAddressId { get; set; }
    public Guid DeliveryMethodId { get; set; }
}
