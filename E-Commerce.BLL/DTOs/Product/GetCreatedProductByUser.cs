

namespace E_Commerce.BLL.DTOs;

public class GetCreatedProductByUser
{
    public string UserId { get; set; } = string.Empty;
    public int PageNumber { get; set; }
}
