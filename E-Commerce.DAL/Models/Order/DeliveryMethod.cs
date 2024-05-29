namespace E_Commerce.DAL.Models;

public class DeliveryMethod : BaseModel<Guid>
{
	public string ShortName { get; set; } = string.Empty;
	public string DeliveryTime { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public ICollection<Order>? Orders { get; set; }
}
