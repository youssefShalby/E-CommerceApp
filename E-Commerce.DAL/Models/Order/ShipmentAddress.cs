
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL.Models;

public class ShipmentAddress
{
	[Required(ErrorMessage = "the field is required..!!")]
	[MaxLength(50, ErrorMessage = "the number of chars cannot be larger than 50 char")]
	[MinLength(2, ErrorMessage = "the number of chars cannot be less than 2 char")]
	public string FirstName { get; set; } = string.Empty;

	[Required(ErrorMessage = "the field is required..!!")]
	[MaxLength(50, ErrorMessage = "the number of chars cannot be larger than 50 char")]
	[MinLength(2, ErrorMessage = "the number of chars cannot be less than 2 char")]
	public string LastName { get; set; } = string.Empty;

	[Required(ErrorMessage = "the field is required..!!")]
	[MaxLength(50, ErrorMessage = "the number of chars cannot be larger than 50 char")]
	[MinLength(2, ErrorMessage = "the number of chars cannot be less than 2 char")]
	public string Street { get; set; } = string.Empty;

	[Required(ErrorMessage = "the field is required..!!")]
	[MaxLength(50, ErrorMessage = "the number of chars cannot be larger than 50 char")]
	[MinLength(2, ErrorMessage = "the number of chars cannot be less than 2 char")]
	public string City { get; set; } = string.Empty;

	[Required(ErrorMessage = "the field is required..!!")]
	[MaxLength(50, ErrorMessage = "the number of chars cannot be larger than 50 char")]
	[MinLength(2, ErrorMessage = "the number of chars cannot be less than 2 char")]
	public string State { get; set; } = string.Empty;

	[Required(ErrorMessage = "the field is required..!!")]
	[MaxLength(4, ErrorMessage = "the number of chars cannot be larger than 4 char")]
	[MinLength(4, ErrorMessage = "the number of chars cannot be less than 4 char")]
	public string Zipcode { get; set; } = string.Empty;
}
