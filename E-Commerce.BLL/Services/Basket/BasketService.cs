

namespace E_Commerce.BLL.Services;

public class BasketService : IBasketService
{
	private readonly IRedisService _redisService;
    public BasketService(IRedisService redisService)
    {
        _redisService = redisService;
    }

    public async Task<CustomerBasket> GetBasketAsync(string id)
	{
		return await _redisService.GetDataAsync<CustomerBasket>(id);
	}

	public async Task<bool> RmoveBasketAsync(string id)
	{
		return await _redisService.RemoveDataAsync<bool>(id);
	}

	public async Task<CustomerBasket> SetOrUpdateBasketAsync(CustomerBasket basket)
	{
		var created = await _redisService.SetDataAsync(basket.Id, basket, DateTimeOffset.Now.AddDays(10));
		if (created)
		{
			return await GetBasketAsync(basket.Id);
		}
		return null!;
	}
}
