
namespace E_Commerce.BLL.DTOs;

public class GetCreatedOrdersByUser 
{
	public string UserEmail { get; set; } = string.Empty;
	public int PageNumber { get; set; }
}
