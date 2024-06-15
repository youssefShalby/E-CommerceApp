

namespace E_Commerce.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(policy: "SuperAdmin")]
public class SuperAdminDashboardController : ControllerBase
{
	private readonly IUserService _userService;
	public SuperAdminDashboardController(IUserService userService)
	{
		_userService = userService;
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
