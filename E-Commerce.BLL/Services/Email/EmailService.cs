


using MimeKit;
using MailKit.Net.Smtp;


namespace E_Commerce.BLL.Services;

public class EmailService : IEmailService
{
	private readonly SmtpSettings _smtpSettings;
    public EmailService(SmtpSettings smtpSettings)
    {
        _smtpSettings = smtpSettings;
    }

	public async Task<CommonResponse> SendEmailAsync(string toEmail, string subject, string body, bool isHtml = false)
	{
		var emailMessage = new MimeMessage();
		emailMessage.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
		emailMessage.To.Add(new MailboxAddress("", toEmail));
		emailMessage.Subject = subject;

		var bodyBuilder = new BodyBuilder();
		if (isHtml)
		{
			bodyBuilder.HtmlBody = body;
		}
		else
		{
			bodyBuilder.TextBody = body;
		}

		emailMessage.Body = bodyBuilder.ToMessageBody();
		using (var client = new SmtpClient())
		{
			try
			{
				await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
				await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
				await client.SendAsync(emailMessage);
				await client.DisconnectAsync(true);
				return new CommonResponse("the email sended..!!", true);
			}
			catch (Exception ex)
			{
				return new CommonResponse("cannot send the email right now..!!", false);
			}
		}
	}


	public string GenerateOTPCode()
	{
		return new Random().Next(1000, 9999).ToString();
	}

	public string GetConfirmationEmailBody(string otp, string userName = "User")
	{
		return @$"
				<!DOCTYPE html>
				<html lang=""en"">
				<head>
					<meta charset=""UTF-8"">
					<title>Confirmation Email</title>
				</head>
				<body>
					<p>Hi {userName},</p>
					<p>Thank you for signing up with Company Name. To complete your account verification, enter the following One-Time Password (OTP) code:</p>
					<p style=""font-weight: bold; font-size: 16px;"">{otp}</p>
					<p>This code is valid for [duration] minutes. Please do not share this code with anyone.</p>
					<p>If you did not initiate this request, please disregard this email and contact our support team.</p>
					<p>Sincerely,</p>
					<p>E-CommerceApp</p>
				</body>
				</html>
				";
	}
	public string ResetPasswordEmailBody(string url)
	{
		return @$"<!DOCTYPE html>
                <html lang=""en"">
                <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>Password Reset</title>
                <style>
                    /* Reset CSS */
                    body, html {{
                    margin: 0;
                    padding: 0;
                    font-family: Arial, sans-serif;
                    }}
                    /* Wrapper */
                    .wrapper {{
                    max-width: 600px;
                    margin: 0 auto;
                    padding: 20px;
                    }}
                    /* Header */
                    .header {{
                    text-align: center;
                    margin-bottom: 20px;
                    }}
                    /* Content */
                    .content {{
                    background-color: #f9f9f9;
                    padding: 20px;
                    border-radius: 5px;
                    }}
                    /* Button */
                    .button {{
                    display: inline-block;
                    background-color: #007bff;
                    color: #fff;
                    text-decoration: none;
                    padding: 10px 20px;
                    border-radius: 5px;
                    }}
                </style>
                </head>
                <body>
                <div class=""wrapper"">
                    <div class=""header"">
                    <h1>Password Reset</h1>
                    </div>
                    <div class=""content"">
                    <p>You have requested a password reset. Click the button below to reset your password:</p>
                    <p><a class=""button"" href='{url}'>Reset Password</a></p>
                    <p>If you didn't request a password reset, you can safely ignore this email.</p>
                    </div>
                </div>
                </body>
                </html>
";
	}
}
