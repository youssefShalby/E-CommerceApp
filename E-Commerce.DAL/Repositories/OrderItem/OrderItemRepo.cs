

namespace E_Commerce.DAL.Repositories;

public class OrderItemRepo : GenericRepo<OrderItem>, IOrderItemRepo
{
    public OrderItemRepo(AppDbContext context, IConfiguration configuration) : base(context, configuration)
    {
        
    }
}
