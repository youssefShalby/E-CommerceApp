

namespace E_Commerce.BLL.Services;

public class TokenService : ITokenService
{
	private readonly IConfiguration _configuration;
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly IHttpContextAccessor _httpContextAccessor;
	public TokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
	{
		_configuration = configuration;
		_userManager = userManager;
		_httpContextAccessor = httpContextAccessor;
	}
	public JwtSecurityToken CreateToken(List<Claim> claims, DateTime expireationTime)
	{
		return new JwtSecurityToken(
			issuer: _configuration["JWT:Issuer"],
			audience: _configuration["JWT:Audiences"],
			notBefore: DateTime.Now,
			expires: expireationTime,
			signingCredentials: GetCredentials()
			);
	}

	public SigningCredentials GetCredentials()
	{
		return new SigningCredentials(GetKey(), SecurityAlgorithms.HmacSha256Signature);
	}
	public SymmetricSecurityKey GetKey()
	{
		var keyInBytes = Encoding.ASCII.GetBytes(GetKeyAsString());
		return new SymmetricSecurityKey(keyInBytes);
	}

	public string GetKeyAsString()
	{
		return _configuration["Jwt:TokenKey"];
	}

	public JwtSecurityToken ReadToken(string token)
	{
		//> will return token as json
		JwtSecurityTokenHandler handler = new();

		//> read and cast the token
		var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
		if (jsonToken is null) return null!;
		return jsonToken;
	}

	public string ExtractClaimFromToken(string token, string tokenClaim)
	{
		//> read token
		var jsonToken = ReadToken(token);
		var claimValue = jsonToken.Claims.FirstOrDefault(claim => claim.Type == tokenClaim)?.Value;
		return claimValue ?? null!;
	}

	public DateTime GetExpirationTimeOfToken(string token)
	{
		//> read token and access ValidTo prop
		return ReadToken(token).ValidTo;
	}
	public bool IsTokenExpired(string token)
	{
		DateTime expireTime = ReadToken(token).ValidTo;
		return DateTimeOffset.UtcNow >= expireTime;
	}

	public async Task<string> CreateLoginToken(ApplicationUser user)
	{
		//> get user claims from database
		var userClaims = await _userManager.GetClaimsAsync(user);

		if (userClaims is null) return "NA";

		//> add JWTRegisteredClaimNames.Jti to the claims => Id of token by using Guid().NewGuid().ToString()
		userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

		//> generate the token by claims
		int numberOfDays = int.Parse(_configuration["JWT:TokenExpirePerDay"]);
		var generateToken = CreateToken(userClaims.ToList(), DateTime.Now.AddDays(numberOfDays));
		return new JwtSecurityTokenHandler().WriteToken(generateToken);
	}

	public int SaveTokenInCookie(string token)
	{
		//> get HttpContext from the Service
		var httpContext = _httpContextAccessor.HttpContext;
		if(httpContext is null) return -1;

		var cookieOption = new CookieOptions
		{
			//> make expiration of cookie match the expiration of token
			Expires = GetExpirationTimeOfToken(token)
		};

		httpContext.Response.Cookies.Append("loginToken", token, cookieOption);
		return 0;
	}
}
