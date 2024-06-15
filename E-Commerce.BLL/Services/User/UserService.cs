


namespace E_Commerce.BLL.Services;

public class UserService : IUserService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IHandlerService _handlerService;
	private readonly ITokenService _tokenService;
	private readonly SignInManager<ApplicationUser> _signInManager;
	private readonly IEmailService _emailService;
	private readonly IHttpContextAccessor _httpContextAccessor;
    public UserService(IUnitOfWork unitOfWork, IHandlerService handlerService, ITokenService tokenService, SignInManager<ApplicationUser> signInManager, IEmailService emailService, IHttpContextAccessor httpContextAccessor)
    {
		_unitOfWork = unitOfWork;
		_handlerService = handlerService;
		_tokenService = tokenService;
		_signInManager = signInManager;
		_emailService = emailService;
		_httpContextAccessor = httpContextAccessor;
    }

	public async Task<CommonResponse> RegisterAsync(RegisterUserDto model)
	{
		var UserRole = await _unitOfWork.RoleManager.FindByNameAsync("User");
		if(UserRole is null)
		{
			return new CommonResponse("cannot create user because the 'User' role is not found, create the 'User' role first and then create user", false);
		}
		return await _handlerService.RegisterHandlerAsync(model, UserRole.Name, UserRole.Name);
	}

	public async Task<CommonResponse> RegisterSuperAdminAsync(string key, RegisterUserDto model)
	{
		var SuperAdminRole = await _unitOfWork.RoleManager.FindByNameAsync("SuperAdmin");
		var AdminRole = await _unitOfWork.RoleManager.FindByNameAsync("Admin");
		if (SuperAdminRole is null || AdminRole is null)
		{
			return new CommonResponse("cannot create super admin right now because the admin roles not founded", false);
		}
		return await _handlerService.RegisterHandlerAsync(model, SuperAdminRole.Name, SuperAdminRole.Name, AdminRole.Name);
	}

	public async Task<CommonResponse> ConfirmEmailAsync(VerificationCodeDto model)
	{
		var user = await _unitOfWork.UserManager.FindByIdAsync(model.UserId);
		if(user is null)
		{
			return new CommonResponse("user not registered...", false);
		}

		if(user.EmailConfirmed)
		{
			return new CommonResponse("Email already confirmed..!!", true);
		}

		//> get token and verification code from db
		var token = user.ConfirmationCodeToken;
		var verificationCode = user.ConfirmationCode;

		if (token is null || verificationCode is null) 
		{
			return new CommonResponse("verification code expired, order new one", false);
		}

		if(_tokenService.IsTokenExpired(token))
		{
			return new CommonResponse("the entred code is expired, order new one", false);
		}

		//> ensure the code is right
		if(model.Code == null || verificationCode != model.Code || model.Code.Length < 4)
		{
			return new CommonResponse("the code is not valid", false);
		}

		user.EmailConfirmed = true;
		IdentityResult result = await _unitOfWork.UserManager.UpdateAsync(user);
		if(!result.Succeeded)
		{
			var errors = _handlerService.GetErrorsOfIdentityResult(result.Errors);
			return new CommonResponse("cannot confirm email right now, try again later", false, errors);
		}

		user.ConfirmationCodeToken = null!;
		user.ConfirmationCode = null!;
		var updated = await _unitOfWork.UserManager.UpdateAsync(user);

		//> then, create login token and save it in the cookie after email confirmation process to make user loged in
		string loginToken = await _tokenService.CreateLoginToken(user);
		if(loginToken == "NA")
		{
			return new CommonResponse("email confirmed success, but cannot loging you in automatically, you can login now", true);
		}

		//> save login token in the cookie
		int added = _tokenService.SaveTokenInCookie(loginToken, user.Id);
		if(added == -1)
		{
			return new CommonResponse("email confirmed success, but cannot loging you in automatically, you can login now", true);
		}
		return new CommonResponse("User Confirmed Successfully, and logged in now", true);
	}

	public async Task<CommonResponse> LoginAsync(LoginDto model)
	{
		//> check email is true and exist
		ApplicationUser user = await _unitOfWork.UserManager.FindByEmailAsync(model.Email);
		if(user is null)
		{
			return new CommonResponse("Email Not Found..!", false);
		}

		//> get last five chars from the Id
		string theCheckId = Handler.GetFirstFiveChardsFromId(user.Id);

		//> check if there is login token in cookie or not
		var httpContext = _httpContextAccessor.HttpContext;
		var checkLoginToken = httpContext?.Request.Cookies.FirstOrDefault(TK => TK.Key == $"loginToken-{theCheckId}");
		if (checkLoginToken?.Value is not null)
		{
			return new CommonResponse("user already loged in", false);
		}

		//> check email is confirmed or not, if not return id to confirm it
		if (!user.EmailConfirmed)
		{
			var verificationModel = new VerificationCodeDto(user.Id);
			return new CommonResponse("email not confirmed, please confirm it then login", false, null!, verificationModel.UserId);
		}

		//> check account is blocked or not
		if(await _unitOfWork.UserManager.IsLockedOutAsync(user))
		{
			return new CommonResponse("your account is blocked for while, try again later", false);
		}

		//> above checks is right, check the password is right and valid or not
		var IsAhthenticated = await _unitOfWork.UserManager.CheckPasswordAsync(user, model.Password);

		//> if password is not correct, increment number of tries and tell user pass is not correct
		if(!IsAhthenticated)
		{
			return new CommonResponse("the Password Is Not Correct", false);
		}

		//> if email and password are correct, create the token
		string token = await _tokenService.CreateLoginToken(user);
		DateTime expireTime = _tokenService.GetExpirationTimeOfToken(token);

		//> save the token in the cookie
		int added = _tokenService.SaveTokenInCookie(token, user.Id);
		if(added == -1)
		{
			return new CommonResponse("login success, but cannot save data in your browser for now", true);
		}

		//> return the token with expiration time
		var tokenResponse = new TokenDto(token, expireTime);
		return new CommonResponse("Login Success", true, null!, tokenResponse);
	}

	public async Task<CommonResponse> ForgetPasswordAsync(string email)
	{
		//> get the user by email and check user exist or not
		var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
		if(user is null)
		{
			return new CommonResponse("User Not Found...!!", false);
		}

		var generateToken = await _unitOfWork.UserManager.GeneratePasswordResetTokenAsync(user);

		//> clear token from special chars
		var tokenInBytes = Encoding.UTF8.GetBytes(generateToken);
		var token = WebEncoders.Base64UrlEncode(tokenInBytes);

		string url = $"{_unitOfWork.Configuration.GetValue<string>("AppUrl")}/ResetPassword?email={email}&token={token}";
		string emailBody = _emailService.ResetPasswordEmailBody(url);
		var sended = await _emailService.SendEmailAsync(email, "Reset Password", emailBody, true);
		if(!sended.IsSuccessed)
		{
			return sended;
		}
		return new CommonResponse("Reset Password Requested, check your inbox", true);
	}

	public async Task<CommonResponse> ResetPasswordAsync(ResetPasswordDto model, string token)
	{
		var user = await _unitOfWork.UserManager.FindByEmailAsync(model.Email);
		if (user is null)
		{
			return new CommonResponse("User Not Found...!!", false);
		}

		if(model.NewPassword != model.ConfirmPassword)
		{
			return new CommonResponse("Passswords Does not Match..!!", false);
		}

		//> decode token and extract it
		var decodedToken = WebEncoders.Base64UrlDecode(token);
		var originalToken = Encoding.UTF8.GetString(decodedToken);

		var result = await _unitOfWork.UserManager.ResetPasswordAsync(user, originalToken, model.NewPassword);
		if(!result.Succeeded)
		{
			return new CommonResponse("cannot change password for now because the link is expired, order new one", false);
		}
		return new CommonResponse("password changes success", true);
		
	}

	public async Task<CommonResponse> LogoutAsync(string email)
	{
		var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
		if(user is null)
		{
			return new CommonResponse("user not founded..!!", false);
		}

		var theCookieId = Handler.GetFirstFiveChardsFromId(user.Id);

		//> delete the loginToken
		var httpContext = _httpContextAccessor.HttpContext;
		httpContext?.Response.Cookies.Delete($"loginToken-{theCookieId}");

		return new CommonResponse("Signed out success", true);
	}

	public async Task<CommonResponse> RemoveAccountAsync(RemoveAccountDto model)
	{
		if (string.IsNullOrEmpty(model.Email))
		{
			return new CommonResponse("email is not valid..!!", false);
		}

		var user = await _unitOfWork.UserManager.FindByEmailAsync(model.Email);
		if (user is null)
		{
			return new CommonResponse("user not found..!!", false);
		}

		//> check password is valid or not
		var passwordIsValid = await _unitOfWork.UserManager.CheckPasswordAsync(user, model.Password);
		if(!passwordIsValid)
		{
			return new CommonResponse("Password Is Not Valid..!!", false);
		}

		IdentityResult result = await _unitOfWork.UserManager.DeleteAsync(user);
		if(!result.Succeeded)
		{
			return new CommonResponse("cannot delete account for now, try again later..!!", false);
		}

		//> if remove success, delete cookies and tokens from browser
		await LogoutAsync(user.Email);

		return new CommonResponse("Account Deleted.. bye bye", true);
	}

	public async Task<CommonResponse> ResendConfirmationEmail(string email)
	{
		var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
		if (user is null)
		{
			return new CommonResponse("the email is not exist..!!", false);
		}

		string verificationCode = _emailService.GenerateOTPCode();
		string emailBody = _emailService.GetConfirmationEmailBody(verificationCode, email);

		var userClaims = await _unitOfWork.UserManager.GetClaimsAsync(user);
		var generateToken = _tokenService.CreateToken(userClaims.ToList(), DateTime.Now.AddMinutes(5));
		string token = new JwtSecurityTokenHandler().WriteToken(generateToken);

		user.ConfirmationCode = verificationCode;
		user.ConfirmationCodeToken = token;
		var updated = await _unitOfWork.UserManager.UpdateAsync(user);
		if (!updated.Succeeded)
		{
			return new CommonResponse("cannot resend the email confirmation..!!", true);
		}

		var sended = await _emailService.SendEmailAsync(email, "Confirm Email", emailBody, true);
		if (!sended.IsSuccessed)
		{
			return sended;
		}

		return new CommonResponse("the email resended success..!!", true);

	}

	public async Task<ApplicationUser> GetUserByEmailAsync(string email)
	{
		var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
		if(user is null)
		{
			return null!;
		}
		return user;
	}

	public async Task<CommonResponse> UpdateUserAddressAsync(string email, IdentityAddressDto model)
	{
		var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
		if (user is null)
		{
			return new CommonResponse("user not founded..!!", false);
		}
		
		user.Address = AddressMapper.ToAddressModel(model);

		var result = await _unitOfWork.UserManager.UpdateAsync(user);
		if (!result.Succeeded)
		{
			return new CommonResponse("cannot update address right now, try again later..!", false);
		}
		return new CommonResponse("address updated..!!", true);
	}

	public async Task<CommonResponse> UpdateUserInfoAsync(string email, UpdateAccountDto model)
	{
		var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
		if (user is null)
		{
			return new CommonResponse("user not founded..!!", false);
		}

		var isUserNameExist = await _unitOfWork.UserManager.FindByNameAsync(user.UserName);
		if(isUserNameExist is null)
		{
			return new CommonResponse("user name already taken..!!", false);
		}

		user.UserName = model.UserName;
		user.DisplayName = model.DisplayName;

		var result = await _unitOfWork.UserManager.UpdateAsync(user);
		if (!result.Succeeded)
		{
			return new CommonResponse("cannot update user right now, try again later..!", false);
		}

		return new CommonResponse("user info updated..!!", true);
	}

	public async Task<CommonResponse> MarkUserAsAdminAsync(MarkUserAsAdminDto model)
	{
		var user = await _unitOfWork.UserManager.FindByEmailAsync(model.Email);
		if (user is null)
		{
			return new CommonResponse("user not founded..!!", false);
		}

		if (await _unitOfWork.UserManager.IsInRoleAsync(user, "Admin"))
		{
			return new CommonResponse("the User already have 'Admin' role..!!", false);
		}

		if (model.IsAdmin)
		{
			var cliams = await _unitOfWork.UserManager.GetClaimsAsync(user);
			var oldRoleClaim = cliams.FirstOrDefault(C => C.Type == ClaimTypes.Role);
			
			var resultOfRmove = await _unitOfWork.UserManager.RemoveClaimAsync(user, oldRoleClaim);
			if (!resultOfRmove.Succeeded)
			{
				return new CommonResponse("cannot remove old role..!!", false);
			}

			var resultOfAddClaim  = await _unitOfWork.UserManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin"));
			if (!resultOfAddClaim.Succeeded)
			{
				return new CommonResponse("cannot update the claim of user..!!", false);
			}

			var resutlOfAddRole = await _unitOfWork.UserManager.AddToRoleAsync(user, "Admin");
			if (!resutlOfAddRole.Succeeded)
			{
				return new CommonResponse("cannot assign new role..!!", false);
			}

			//> mark user as admin
			user.IsAdmin = true;

			var result = await _unitOfWork.UserManager.UpdateAsync(user);
			if (!result.Succeeded)
			{
				return new CommonResponse("cannot assign the new role for the user right now, try again later..!", false);
			}

			return new CommonResponse("the role assigned to the user..!!", true);
		}
		return new CommonResponse("the admin role not assigned to the user..!!", false);


	}
}
