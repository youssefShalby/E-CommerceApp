


namespace E_Commerce.BLL.Services;

public interface ITokenService
{
	JwtSecurityToken CreateToken(List<Claim> claims, DateTime expireationTime);
	SigningCredentials GetCredentials();
	SymmetricSecurityKey GetKey();
	string GetKeyAsString();
	JwtSecurityToken ReadToken(string token);
	string ExtractClaimFromToken(string token, string tokenClaim);
	DateTime GetExpirationTimeOfToken(string token);
	bool IsTokenExpired(string token);
	Task<string> CreateLoginToken(ApplicationUser user);
	int SaveTokenInCookie(string token);
}
