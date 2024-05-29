namespace E_Commerce.BLL.DTOs;

public class BasketItemsDto
{
	public string ProductName { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public int Quantity { get; set; }
	public string BrandName { get; set; } = string.Empty;
	public string CategoryName { get; set; } = string.Empty;
	public IEnumerable<string>? ImagesUrl { get; set; }
}
