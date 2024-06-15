

using StackExchange.Redis;

namespace E_Commerce.BLL.Services;

public class RedisService : IRedisService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IDatabase _cacheDb;
	private readonly ILogger<RedisService> _logger;

	public RedisService(IUnitOfWork unitOfWork, ILogger<RedisService> logger)
    {
		_unitOfWork = unitOfWork;
		_logger = logger;
		try
		{
			var redis = ConnectionMultiplexer.Connect(_unitOfWork.Configuration.GetConnectionString("Redis"));
			_cacheDb = redis.GetDatabase();
		}
		catch(Exception ex)
		{
			_logger.LogError($"run the Redis Server now, {ex.Message}");
			_cacheDb = null!;
		}
		
	}

	public async Task<T> GetDataAsync<T>(string key)
	{
		var value = await _cacheDb.StringGetAsync(key);
		if(!string.IsNullOrEmpty(value))
		{
			return JsonSerializer.Deserialize<T>(value!)!;
		}
		return default!;
	}

	public async Task<bool> RemoveDataAsync<T>(string key)
	{
		var isExist = await _cacheDb.KeyExistsAsync(key);
		if(isExist)
		{
			return await _cacheDb.KeyDeleteAsync(key);
		}
		return false;
	}

	public async Task<bool> SetDataAsync<T>(string key, T value, DateTimeOffset expirationTime)
	{
		var expireTime = expirationTime.DateTime.Subtract(DateTime.Now);
		return await _cacheDb.StringSetAsync(key, JsonSerializer.Serialize(value), expireTime);
	}
}
