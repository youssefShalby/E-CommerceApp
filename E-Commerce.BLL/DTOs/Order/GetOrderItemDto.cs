
namespace E_Commerce.BLL.DTOs;

public class GetOrderItemDto
{
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public int Quantity { get; set; }
}
