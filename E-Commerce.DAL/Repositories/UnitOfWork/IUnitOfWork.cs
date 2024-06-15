

using Microsoft.Extensions.Logging;

namespace E_Commerce.DAL.Repositories;

public interface IUnitOfWork
{
    public IBrandRepo BrandRepo { get; }
    public ICategoryRepo CategoryRepo { get; }
    public IDeliveryMethodRepo DeliveryMethodRepo { get; }
    public IImageRepo ImageRepo { get; }
    public IOrderRepo OrderRepo { get; }
    public IOrderItemRepo OrderItemRepo { get; }
    public IProductRepo ProductRepo { get; }
    public UserManager<ApplicationUser> UserManager { get; }
    public RoleManager<IdentityRole> RoleManager { get; }
    public IConfiguration Configuration { get; }
}
