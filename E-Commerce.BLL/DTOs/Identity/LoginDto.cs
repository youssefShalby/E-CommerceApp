
namespace E_Commerce.BLL.DTOs;

public class LoginDto
{
	[EmailAddress(ErrorMessage = "Email is not valid..!!")]
	[Required(ErrorMessage = "the email is reqired...!!")]
	public string Email { get; set; } = string.Empty;

	[Required]
	public string Password { get; set; } = string.Empty;
}
