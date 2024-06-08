
namespace E_Commerce.BLL.DTOs;

public class StripeSettings
{
    public string PublishableKey { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
    public string webHooksSecret { get; set; } = string.Empty;
}
