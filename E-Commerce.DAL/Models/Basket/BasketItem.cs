
namespace E_Commerce.DAL.Models;

public class BasketItem:BaseModel<Guid>
{
	public string ProductName { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public int Quantity { get; set; }
	public string BrandName { get; set; } = string.Empty;
	public string CategoryName { get; set; } = string.Empty;
	public IEnumerable<string>? ImagesUrl { get; set; }
}
