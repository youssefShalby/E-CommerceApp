

namespace E_Commerce.BLL.DTOs;

public class CreateCategoryDto
{

	[Required(ErrorMessage = "The Name is Required..!!")]
	[MaxLength(100, ErrorMessage = "The Name Cannot be larger than 100 char")]
	public string Name { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; } = DateTime.Now;
}
