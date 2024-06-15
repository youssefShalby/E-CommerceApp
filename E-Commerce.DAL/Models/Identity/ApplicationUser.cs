
namespace E_Commerce.DAL.Models;

public class ApplicationUser : IdentityUser
{
    public string DisplayName { get; set; } = string.Empty;
    public string? ConfirmationCode { get; set; }
    public bool IsAdmin { get; set; }
    public string? ConfirmationCodeToken { get; set; }
    public Address? Address { get; set; }
    public ICollection<Product>? Products { get; set; }

}
