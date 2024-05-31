
namespace E_Commerce.BLL.DTOs;

public class CreateDeliveryMethodDto
{
	public string ShortName { get; set; } = string.Empty;
	public string DeliveryTime { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public decimal Price { get; set; }
}
