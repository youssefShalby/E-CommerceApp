﻿

namespace E_Commerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InfoController : ControllerBase
{
	private readonly IUserService _userService;
	public InfoController(IUserService userService)
	{
		_userService = userService;
	}


	[HttpGet("GetAddress")]
	[Authorize]
	public async Task<ActionResult<IdentityAddressDto>> GetAddress()
	{
		var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value ?? null!;
		if (userEmail is null)
		{
			return NoContent();
		}

		var user = await _userService.GetUserByEmailAsync(userEmail);

		return AddressMapper.ToAddressDto(user.Address ?? new Address());
	}

	[HttpPut("UpdateAddress")]
	[Authorize]
	public async Task<ActionResult> UpdateAddress(IdentityAddressDto model)
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

	[HttpPut("UpdateInfo")]
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
