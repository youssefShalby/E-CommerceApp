

namespace E_Commerce.BLL.Services;

public interface IPaymentService
{
	Task<CustomerBasket> CreateOrUpdatePaymentIntentAsync(string basketId);
	Task<Order> UpdateOrderWhenPaymentFailAsync(string paymentIntentId);
	Task<Order> UpdateOrderWhenPaymentSuccessAsync(string paymentIntentId);
}
