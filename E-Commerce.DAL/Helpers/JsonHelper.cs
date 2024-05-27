

namespace E_Commerce.DAL.Helpers;

public static class JsonHelper
{
	public static List<T> GetSeedData<T>(string pathOfJsonFile)
	{
		string fileContent = File.ReadAllText(pathOfJsonFile);
		return JsonSerializer.Deserialize<List<T>>(fileContent)!;
	}
}
