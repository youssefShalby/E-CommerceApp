

namespace E_Commerce.DAL.Models;

public class OrderItem : BaseModel<Guid>
{
    public ProductOrderItem? ItemOrdered { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid? OrderId { get; set; }
}
