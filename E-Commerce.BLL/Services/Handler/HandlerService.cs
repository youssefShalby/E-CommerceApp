

namespace E_Commerce.BLL.Services;

public class HandlerService : IHandlerService
{
	private readonly IEmailService _emailService;
	private readonly ITokenService _tokenService;
	private readonly IUnitOfWork _unitOfWork;
	public HandlerService(IUnitOfWork unitOfWork, IEmailService emailService, ITokenService tokenService)
	{
		_unitOfWork = unitOfWork;
		_emailService = emailService;
		_tokenService = tokenService;
	}

	public List<string> GetErrorsOfIdentityResult(IEnumerable<IdentityError> errors)
	{
		List<string> errorResult = new List<string>(5);
		foreach (var error in errors)
		{
			errorResult.Add(error.Description ?? "NA");
		}
		return errorResult;
	}

	public async Task<CommonResponse> RegisterHandlerAsync(RegisterUserDto model, string mainRole, params string[] otherRoles)
	{

		#region check user already exist or not

		var IsUserNameExist = await _unitOfWork.UserManager.FindByNameAsync(model.Email);
		var IsUserEmailExist = await _unitOfWork.UserManager.FindByEmailAsync(model.Email);

		if(IsUserNameExist is not null)
		{
			return new CommonResponse("the email already exist, please try another one", false);
		}

		if (IsUserEmailExist is not null)
		{
			return new CommonResponse("the User Name already exist, please try another one", false);
		}

		#endregion

		#region Map the UserDTO to the Domain Model & Initial the Claims

		ApplicationUser AppUser = new ApplicationUser
		{
			UserName = model.UserName,
			Email = model.Email,
			DisplayName = model.FullName
		};
		AppUser.Address = new Address
		{
			Id = Guid.NewGuid(),
			State = model.Address,
			AppUserId = AppUser.Id,
		};

		if (mainRole == "Admin" || mainRole == "SuperAdmin")
		{
			AppUser.IsAdmin = true;
		}

		List<Claim> UserClaims = new List<Claim>(5)
		{
			new Claim(ClaimTypes.NameIdentifier, AppUser.Id),
			new Claim(ClaimTypes.Name, AppUser.UserName),
			new Claim(ClaimTypes.Email, AppUser.Email),
			new Claim(ClaimTypes.Role, mainRole)
		};

		#endregion

		#region Get Ready to send email & Create Token & create Token Claims

		string verificationCode = _emailService.GenerateOTPCode();
		string emailBody = _emailService.GetConfirmationEmailBody(verificationCode, AppUser.DisplayName);

		List<Claim> tokenClaims = new List<Claim>()
		{
			new Claim("VerificationCode", verificationCode),
			new Claim(ClaimTypes.Email, model.Email),

			//> add role of User to the Token
			new Claim(ClaimTypes.Role, mainRole)
		};

		//> create token for the verification code
		var generateToken = _tokenService.CreateToken(tokenClaims, DateTime.Now.AddMinutes(5));
		string token = new JwtSecurityTokenHandler().WriteToken(generateToken);

		//> can cache token in in Redis Database, but here will save it in Db
		AppUser.ConfirmationCodeToken = token;
		AppUser.ConfirmationCode = verificationCode;

		#endregion

		#region Create User - AddRole to User - Add Claims - Send ConfirmationEmail

		IdentityResult result = await _unitOfWork.UserManager.CreateAsync(AppUser, model.Password);
		if(!result.Succeeded)
		{
			var errors = GetErrorsOfIdentityResult(result.Errors);
			return new CommonResponse("cannot create User", false, errors);
		}

		//> add the claims to claims table in Db & Add roles for the User
		await _unitOfWork.UserManager.AddClaimsAsync(AppUser, UserClaims);
		await _unitOfWork.UserManager.AddToRolesAsync(AppUser, otherRoles);

		//> send confirmation email
		var sended = await _emailService.SendEmailAsync(AppUser.Email, "Confirm Email", emailBody, true);
		if(!sended.IsSuccessed)
		{
			return sended;
		}

		#endregion

		var verificationModel = new VerificationCodeDto(AppUser.Id);
		return new CommonResponse("check your inbox to confrim the email", true, null!, verificationModel.UserId);


	}
}
