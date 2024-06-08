

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Text.Json;

namespace E_Commerce.BLL.Services;

public class RedisService : IRedisService
{
	private readonly IConfiguration _configuration;
	private readonly IDatabase _cacheDb;
	private readonly ILogger<RedisService> _logger;

	public RedisService(IConfiguration configuration, ILogger<RedisService> logger)
    {
		_configuration = configuration;
		_logger = logger;
		try
		{
			var redis = ConnectionMultiplexer.Connect(_configuration.GetConnectionString("Redis"));
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
