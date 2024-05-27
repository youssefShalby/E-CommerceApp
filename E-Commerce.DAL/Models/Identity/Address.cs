

namespace E_Commerce.DAL.Models;

public class Address: BaseModel<Guid>
{
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string Street { get; set; } = string.Empty;
	public string City { get; set; } = string.Empty;
	public string State { get; set; } = string.Empty;
	public string Zipcode { get; set; } = string.Empty;
	public ApplicationUser AppUser { get; set; } = new();

	[ForeignKey(nameof(AppUser))]
    public string AppUserId { get; set; } = string.Empty;
}
