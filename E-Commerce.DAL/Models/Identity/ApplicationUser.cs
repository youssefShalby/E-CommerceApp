
namespace E_Commerce.DAL.Models;

public class ApplicationUser : IdentityUser
{
    public string DisplayName { get; set; } = string.Empty;
    public string ConfirmationCode { get; set; } = string.Empty;
    public string ConfirmationCodeToken { get; set; } = string.Empty;
    public Address Address { get; set; } = new();

}
