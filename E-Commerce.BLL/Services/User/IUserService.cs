

namespace E_Commerce.BLL.Services;

public interface IUserService
{
	Task<CommonResponse> RegisterAsync(RegisterUserDto model);
	Task<CommonResponse> RegisterSuperAdminAsync(string key, RegisterUserDto model);
	Task<CommonResponse> ConfirmEmailAsync(VerificationCodeDto model);
	Task<CommonResponse> LoginAsync(LoginDto model);
	Task<CommonResponse> ForgetPasswordAsync(string email);
	Task<CommonResponse> ResetPasswordAsync(ResetPasswordDto model, string token);
	Task<CommonResponse> LogoutAsync(string email);
	Task<CommonResponse> RemoveAccountAsync(RemoveAccountDto model);
	Task<CommonResponse> ResendConfirmationEmail(string email);
	Task<ApplicationUser> GetUserByEmailAsync(string email);
	Task<CommonResponse> UpdateUserAddressAsync(string email, IdentityAddressDto model);
	Task<CommonResponse> UpdateUserInfoAsync(string email, UpdateAccountDto model);
	Task<CommonResponse> MarkUserAsAdminAsync(MarkUserAsAdminDto model);
}
