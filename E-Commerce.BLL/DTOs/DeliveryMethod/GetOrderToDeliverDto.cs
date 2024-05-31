
namespace E_Commerce.BLL.DTOs;

public class GetOrderToDeliverDto
{
	public string BuyerEmail { get; set; } = string.Empty;
	public DateTime OrderDate { get; set; } = DateTime.UtcNow;
}
