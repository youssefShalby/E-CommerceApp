
namespace E_Commerce.BLL.Services;

public interface IBasketService
{
	Task<CustomerBasket> GetBasketAsync(string id);
	Task<CustomerBasket> SetOrUpdateBasketAsync(CustomerBasketDto basket);
	Task<bool> RmoveBasketAsync(string id);
}
