

namespace E_Commerce.BLL.DTOs;

public class GetOrderDto
{
	public string BuyerEmail { get; set; } = string.Empty;
	public DateTime OrderDate { get; set; } = DateTime.UtcNow;
	public ShipmentAddress? ShipToAddress { get; set; }
	public string DeliveryMethodName { get; set; } = string.Empty;
    public decimal ShipPrice { get; set; }
	public List<GetOrderItemDto> OrderItems { get; set; } = new();
    public decimal SubTotalPrice { get; set; }
    public decimal TotalPrice { get; set; }
	public string Status { get; set; } = string.Empty;
}
