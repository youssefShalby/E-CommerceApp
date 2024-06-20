

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "SuperAdmin")]
public class SuperAdminDashboardController : CommonEndpointsController
{
	private readonly IUserService _userService;
	private readonly IRoleService _roleService;
	public SuperAdminDashboardController(
		IUserService userService, 
		IOrderService orderService, 
		IProductService productService, 
		ICategoryService categoryService, 
		IBrandService brandService, 
		IRoleService roleService,
		IDeliveryMethodService deliveryMethodService) : 
		base(userService, orderService, productService, categoryService, brandService, deliveryMethodService)
	{
		_userService = userService;
		_roleService = roleService;
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


	[HttpPost("AddRole")]
	public async Task<ActionResult> AddRole(AddRoleDto role)
	{
		var result = await _roleService.CreateRole(role);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

	[HttpDelete("RemoveRole{name:alpha}")]
	public async Task<ActionResult> RemoveRole(string name)
	{
		var result = await _roleService.DeleteRole(name);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}
}
