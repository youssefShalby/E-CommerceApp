
namespace E_Commerce.DAL.Models;

public class ProductOrderItem : BaseModel<Guid>
{
    public string ProductName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

}
