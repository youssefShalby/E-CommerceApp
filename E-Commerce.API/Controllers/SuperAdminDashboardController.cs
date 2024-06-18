

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class SuperAdminDashboardController : CommonEndpointsController
{
	private readonly IUserService _userService;
	public SuperAdminDashboardController(
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


	[HttpPost("MarkUserAsAdmin")]
	public async Task<ActionResult> MarkUserAsAdmin(MarkUserAsAdminDto model)
	{
		var result = await _userService.MarkUserAsAdminAsync(model);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}
}
