namespace E_Commerce.BLL.Services;

public interface IRedisService
{
	Task<T> GetDataAsync<T>(string key);
	Task<bool> SetDataAsync<T>(string key, T value, DateTimeOffset expirationTime);
	Task<bool> RemoveDataAsync<T>(string key);
}
