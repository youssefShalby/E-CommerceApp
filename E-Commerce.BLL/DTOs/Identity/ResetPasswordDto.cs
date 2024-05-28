public class ResetPasswordDto
{

	[EmailAddress, Required]
	public string Email { get; set; } = string.Empty;

	[Required, MinLength(5, ErrorMessage = "so short password"), MaxLength(80, ErrorMessage = "so long password")]
	public string NewPassword { get; set; } = string.Empty;

	[Required, Compare(nameof(NewPassword))]
	public string ConfirmPassword { get; set; } = string.Empty;
}