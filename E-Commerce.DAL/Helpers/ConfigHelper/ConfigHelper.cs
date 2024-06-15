
namespace E_Commerce.DAL.Helpers;

public class ConfigHelper : IConfigHelper
{
	private readonly IConfiguration _configuration;
	public ConfigHelper(IConfiguration configuration)
	{
		_configuration = configuration;
	}


	public int GetPageSize()
	{
		int.TryParse(_configuration["CustomConfiguration:PageSize"], out int pageSize);
		return pageSize;
	}
}
