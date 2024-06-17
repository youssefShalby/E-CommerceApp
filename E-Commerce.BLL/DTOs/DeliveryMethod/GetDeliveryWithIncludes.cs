
namespace E_Commerce.BLL.DTOs;

public class GetDeliveryWithIncludes : GetDeliveryDto
{
    public ICollection<GetOrderToDeliverDto>? Orders { get; set; }
}
