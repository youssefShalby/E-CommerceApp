
namespace E_Commerce.BLL.DTOs;

public class LoginDto
{
	[EmailAddress, Required]
	public string Email { get; set; } = string.Empty;

	[Required]
	public string Password { get; set; } = string.Empty;
}
