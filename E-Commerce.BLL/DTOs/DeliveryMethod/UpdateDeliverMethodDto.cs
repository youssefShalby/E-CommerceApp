

namespace E_Commerce.BLL.DTOs;

public class UpdateDeliverMethodDto
{
	[Required(ErrorMessage = "short name is required..!!")]
	[MaxLength(8, ErrorMessage = "the name cannot be larger than 8 char")]
	public string ShortName { get; set; } = string.Empty;

	[Required(ErrorMessage = "short name is required..!!")]
	[MaxLength(20, ErrorMessage = "the name cannot be larger than 20 char")]
	public string DeliveryTime { get; set; } = string.Empty;

	[Required(ErrorMessage = "short name is required..!!")]
	[MaxLength(250, ErrorMessage = "the name cannot be larger than 250 char")]
	public string Description { get; set; } = string.Empty;
	public decimal Price { get; set; }
}
