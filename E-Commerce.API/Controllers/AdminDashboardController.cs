
namespace E_Commerce.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(policy: "Admin")]
public class AdminDashboardController : CommonEndpointsController
{
	private readonly IUserService _userService;
	public AdminDashboardController(
		IUserService userService,
		IOrderService orderService,
		IProductService productService,
		ICategoryService categoryService,
		IBrandService brandService,
		IDeliveryMethodService deliveryMethodService) :
		base(userService, orderService, productService, categoryService, brandService, deliveryMethodService)
	{
		_userService = userService;
	}





}
