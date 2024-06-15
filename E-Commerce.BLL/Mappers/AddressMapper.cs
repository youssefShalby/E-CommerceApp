


namespace E_Commerce.BLL.Mappers;

public class AddressMapper
{
	public static IdentityAddressDto ToAddressDto(Address address)
	{
		return new IdentityAddressDto
		{
			City = address.City,
			FirstName = address.FirstName,
			LastName = address.LastName,
			State = address.State,
			Street = address.Street,
			Zipcode = address.Zipcode,
		};
	}

	public static Address ToAddressModel(IdentityAddressDto address)
	{
		return new Address
		{
			City = address.City,
			FirstName = address.FirstName,
			LastName = address.LastName,
			State = address.State,
			Street = address.Street,
			Zipcode = address.Zipcode,
		};
	}
}
