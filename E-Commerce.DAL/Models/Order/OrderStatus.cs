

using System.Runtime.Serialization;

namespace E_Commerce.DAL.Models;

public enum OrderStatus
{
	[EnumMember(Value = "Pending")]
	Pending,

	[EnumMember(Value = "PaymentReceived")]
	PaymentReceived,

	[EnumMember(Value = "PaymentFaild")]
	PaymentFaild
}
