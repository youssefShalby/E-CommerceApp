
namespace E_Commerce.BLL.Services;

public interface IBasketService
{
	Task<CustomerBasket> GetBasketAsync(string id);
	Task<CustomerBasket> SetOrUpdateBasketAsync(CustomerBasket basket);
	Task<bool> RmoveBasketAsync(string id);
}
