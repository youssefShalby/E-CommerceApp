

namespace E_Commerce.DAL.Repositories;

public class OrderItemRepo : GenericRepo<OrderItem>, IOrderItemRepo
{
    public OrderItemRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper) : base(context, configuration, helper)
    {
        
    }
}
