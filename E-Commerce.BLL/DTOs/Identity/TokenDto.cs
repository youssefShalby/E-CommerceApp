namespace E_Commerce.BLL.DTOs;

public class TokenDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationTime { get; set; }
    public TokenDto(string token, DateTime expireTime)
    {
        Token = token;
        ExpirationTime = expireTime;
    }
}
