


namespace E_Commerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InfoController : ControllerBase
{
	private readonly IUserService _userService;
	public InfoController(IUserService userService, IConfiguration configuration)
	{
		_userService = userService;
	}


	[HttpGet("Address")]
	[Authorize]
	public async Task<ActionResult<AddressDto>> GetAddress()
	{
		var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value ?? null!;
		if (userEmail is null)
		{
			return NoContent();
		}

		var user = await _userService.GetUserByEmailAsync(userEmail);

		return AddressMapper.ToAddressDto(user.Address ?? new Address());
	}

	[HttpPut("Address")]
	[Authorize]
	public async Task<ActionResult> UpdateAddress(AddressDto model)
	{
		var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value ?? null!;
		if (userEmail is null)
		{
			return NoContent();
		}

		var result = await _userService.UpdateUserAddressAsync(userEmail, model);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

	[HttpPut("updateinfo")]
	[Authorize]
	public async Task<ActionResult> UpdateInfo(UpdateAccountDto model)
	{
		var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value ?? null!;
		if (userEmail is null)
		{
			return NoContent();
		}

		var result = await _userService.UpdateUserInfoAsync(userEmail, model);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}
}
