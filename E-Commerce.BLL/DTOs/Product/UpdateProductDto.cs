
namespace E_Commerce.BLL.DTOs;

public class UpdateProductDto
{
	[Required(ErrorMessage = "The Name is Required..!!")]
	[MaxLength(100, ErrorMessage = "the name cannot be larger than 100 char")]
	[MinLength(3, ErrorMessage = "the name cannot be less than 3 char")]
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public int Stock { get; set; }
	public decimal OriginalPrice { get; set; }
	public decimal OfferPrice { get; set; }
	public Guid CategoryId { get; set; }
	public Guid BrandId { get; set; }
	public string[] ImagesUrl { get; set; } = new string[] { };
}
