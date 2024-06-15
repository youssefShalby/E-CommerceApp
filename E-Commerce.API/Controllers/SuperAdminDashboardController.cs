

namespace E_Commerce.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(policy: "SuperAdmin")]
public class SuperAdminDashboardController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly IConfiguration _configuration;
	public SuperAdminDashboardController(IUserService userService, IConfiguration configuration)
	{
		_userService = userService;
		_configuration = configuration;
	}

	[HttpPost("markUserAsAdmin")]
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
