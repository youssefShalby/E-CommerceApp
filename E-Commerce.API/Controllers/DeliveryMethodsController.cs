

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class DeliveryMethodsController : ControllerBase
{
	private readonly IDeliveryMethodService _deliveryMethodService;
    public DeliveryMethodsController(IDeliveryMethodService deliveryMethodService)
    {
        _deliveryMethodService = deliveryMethodService;
    }

	[HttpGet("All/{pageNumber}")]
	public async Task<ActionResult> GetAll(int page)
	{
		var result = await _deliveryMethodService.GetAllAsync(page);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

	[HttpGet("In/All/{pageNumber}")]
	public async Task<ActionResult> GetAllWithIncludes(int page)
	{
		var result = await _deliveryMethodService.GetAllWithIncludesAsync(page, DM => DM.Orders);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> GetById(Guid id)
	{
		var result = await _deliveryMethodService.GetByIdAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

	[HttpGet("In/{id}")]
	public async Task<ActionResult> GetByIdWithIncludes(Guid id)
	{
		var result = await _deliveryMethodService.GetByIdWithIncludesAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

	[HttpPost]
	public async Task<ActionResult> CreateDeliverMethod(CreateDeliveryMethodDto model)
	{
		var result = await _deliveryMethodService.CreateAsync(model);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateDeliverMethod([FromRoute] Guid id, [FromBody] UpdateDeliverMethodDto model)
	{
		var result = await _deliveryMethodService.UpdateAsync(id, model);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteDeliverMethod([FromRoute] Guid id)
	{
		var result = await _deliveryMethodService.DeleteAsync(id);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}
}
