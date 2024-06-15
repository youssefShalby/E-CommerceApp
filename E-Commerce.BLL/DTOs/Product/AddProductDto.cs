
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BLL.DTOs;

public class AddProductDto
{
	[Required(ErrorMessage = "The Name is Required..!!")]
	[MaxLength(100, ErrorMessage = "the name cannot be larger than 100 char")]
	[MinLength(3, ErrorMessage = "the name cannot be less than 3 char")]
	public string Name { get; set; } = string.Empty;

	[Required(ErrorMessage = "The Description Is Required..!!")]
	[MaxLength(250, ErrorMessage = "the description cannot be larger than 250 char")]
	[MinLength(20, ErrorMessage = "the description cannot be less than 20 char")]
	public string Description { get; set; } = string.Empty;
	public int Stock { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public decimal OriginalPrice { get; set; }
	public decimal OfferPrice { get; set; }
	public Guid CategoryId { get; set; }
	public Guid BrandId { get; set; }
	public string UserId { get; set; } = string.Empty;
	public IEnumerable<string> ImagesUrl { get; set; } = new List<string>();

}
