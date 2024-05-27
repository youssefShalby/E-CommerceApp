
namespace E_Commerce.BLL.DTOs;

public class GetProductDto
{
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public int Stock { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public decimal OriginalPrice { get; set; }
	public decimal OfferPrice { get; set; }
    public IEnumerable<string> ImagesUrl { get; set; } = new List<string>();
}
