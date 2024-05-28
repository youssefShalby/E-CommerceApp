
namespace E_Commerce.BLL.Services;

public interface IEmailService
{
	string GenerateOTPCode();
	Task<CommonResponse> SendEmailAsync(string toEmail, string subject, string body, bool isHtml = false);
	string GetConfirmationEmailBody(string otp, string userName = "User");
	string ResetPasswordEmailBody(string url);


}
