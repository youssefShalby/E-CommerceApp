namespace E_Commerce.API.ApiHelper;

public interface ICacheHelper
{
	Task<T> GetDataFromCache<T>(string cacheKey);
	Task SetDataInCache<T>(string key, T data);
	Task SetDataInShortTimeCache<T>(string key, T data);
}
