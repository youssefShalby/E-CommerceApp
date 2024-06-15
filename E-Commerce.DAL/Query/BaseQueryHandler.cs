

namespace E_Commerce.DAL.Query;

public class BaseQueryHandler
{
	public int PageSize { get; set; } = 10;
	public int PageNumber { get; set; } = 1;
	public bool IsDescending { get; set; }
	public string OrderBy { get; set; } = string.Empty;
}
