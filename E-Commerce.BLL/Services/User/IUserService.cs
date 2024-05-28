
namespace E_Commerce.BLL.Services;

public interface IUserService
{
	Task<CommonResponse> RegisterAsync(RegisterUserDto model);
	Task<CommonResponse> ConfirmEmailAsync(VerificationCodeDto model);
	Task<CommonResponse> LoginAsync(LoginDto model);
	Task<CommonResponse> ForgetPasswordAsync(string email);
	Task<CommonResponse> ResetPasswordAsync(ResetPasswordDto model, string token);
	Task<CommonResponse> LogoutAsync();
	Task<CommonResponse> RemoveAccountAsync(RemoveAccountDto model);
	Task<CommonResponse> ResendConfirmationEmail(string email);
}
