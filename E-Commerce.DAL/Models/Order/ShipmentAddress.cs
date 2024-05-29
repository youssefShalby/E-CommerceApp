
namespace E_Commerce.DAL.Models;

public class ShipmentAddress : BaseModel<Guid>
{
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string Street { get; set; } = string.Empty;
	public string City { get; set; } = string.Empty;
	public string State { get; set; } = string.Empty;
	public string Zipcode { get; set; } = string.Empty;
	public ICollection<Order>? Orders { get; set; }
}
