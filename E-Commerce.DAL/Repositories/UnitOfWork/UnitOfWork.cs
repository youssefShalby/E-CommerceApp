

namespace E_Commerce.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
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

	public UnitOfWork(IBrandRepo brandRepo, ICategoryRepo categoryRepo, IDeliveryMethodRepo deliveryMethodRepo, IImageRepo imageRepo, IOrderRepo orderRepo, IOrderItemRepo orderItemRepo, IProductRepo productRepo, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        BrandRepo = brandRepo;
		CategoryRepo = categoryRepo;
		DeliveryMethodRepo = deliveryMethodRepo;
		ImageRepo = imageRepo;
		OrderRepo = orderRepo;
		ProductRepo = productRepo;
		OrderItemRepo = orderItemRepo;
		UserManager = userManager;
		RoleManager = roleManager;
		Configuration = configuration;
    }

}
