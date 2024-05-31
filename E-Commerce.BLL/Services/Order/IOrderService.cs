
namespace E_Commerce.BLL.Services;

public interface IOrderService
{
	Task<Order> CreateOrderAsync(CreateOrderDto model);
}
