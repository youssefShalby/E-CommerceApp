
namespace E_Commerce.BLL.DTOs;

public class UpdateAccountDto
{
	[Required(ErrorMessage = "enter your name")]
	[MaxLength(100, ErrorMessage = "the name cannot be larger than 100 char")]
	[MinLength(2, ErrorMessage = "the name cannot be less than 3 chars..!!")]
	public string DisplayName { get; set; } = string.Empty;

	[Required(ErrorMessage = "The UserName is required...!!")]
	[MaxLength(80, ErrorMessage = "Too long")]
	[MinLength(2, ErrorMessage = "Too short")]
	public string UserName { get; set; } = string.Empty;
}
