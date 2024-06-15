

namespace E_Commerce.BLL.DTOs;

public class RegisterUserDto
{
	[Required(ErrorMessage = "enter your name")]
	[MaxLength(100, ErrorMessage = "the name cannot be larger than 100 char")]
	[MinLength(2, ErrorMessage = "the name cannot be less than 3 chars..!!")]
	public string FullName { get; set; } = string.Empty;

	[EmailAddress(ErrorMessage = "Email is not valid..!!")]
	[Required(ErrorMessage = "the email is reqired...!!")]
	public string Email { get; set; } = string.Empty;

	[Required(ErrorMessage = "The UserName is required...!!")]
	[MaxLength(80, ErrorMessage = "Too long")]
	[MinLength(2, ErrorMessage = "Too short")]
	public string UserName { get; set; } = string.Empty;

	[Required(ErrorMessage = "Must Assign Address")]
	[MaxLength(80, ErrorMessage = "the address cannot be larger than 80 char")]
	public string Address { get; set; } = string.Empty;

	[Required, MinLength(5, ErrorMessage = "so short password"), MaxLength(80, ErrorMessage = "so long password")]
	public string Password { get; set; } = string.Empty;

	[Required, Compare(nameof(Password))]
	public string ConfirmPassword { get; set; } = string.Empty;
}
