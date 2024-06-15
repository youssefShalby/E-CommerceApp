

namespace E_Commerce.BLL.Mappers;

public class AddressMapper
{
	public static AddressDto ToAddressDto(Address address)
	{
		return new AddressDto
		{
			City = address.City,
			FirstName = address.FirstName,
			LastName = address.LastName,
			State = address.State,
			Street = address.Street,
			Zipcode = address.Zipcode,
		};
	}

	public static Address ToAddressModel(AddressDto address)
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
