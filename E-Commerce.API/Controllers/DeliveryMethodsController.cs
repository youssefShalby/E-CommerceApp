

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class DeliveryMethodsController : ControllerBase
{
	private readonly IDeliveryMethodService _deliveryMethodService;
	private readonly ICacheHelper _cacheHelper;
    public DeliveryMethodsController(IDeliveryMethodService deliveryMethodService, ICacheHelper cacheHelper)
    {
        _deliveryMethodService = deliveryMethodService;
		_cacheHelper = cacheHelper;
    }

	[HttpGet("All/{pageNumber}")]
	public async Task<ActionResult> GetAll(int page)
	{

		var cacheData = "GetAllDelMethod";

		var result = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetDeliveryDto>>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}

		result = await _deliveryMethodService.GetAllAsync(page);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache(cacheData, result);

		return Ok(result);
	}

	[HttpGet("In/All/{pageNumber}")]
	public async Task<ActionResult> GetAllWithIncludes(int page)
	{
		var cacheData = "GetAllDelMethodWithIncludes";

		var result = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetDeliveryWithIncludes>>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}

		result = await _deliveryMethodService.GetAllWithIncludesAsync(page, DM => DM.Orders!);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache(cacheData, result);

		return Ok(result);
	}

	[HttpGet("{id}")]
	[Authorize(Policy = "Admin")]
	public async Task<ActionResult> GetById(Guid id)
	{
		var cacheData = "GetDelMethodById";

		var result = await _cacheHelper.GetDataFromCache<GetDeliveryDto>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}


		result = await _deliveryMethodService.GetByIdAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache<GetDeliveryDto>(cacheData, result);

		return Ok(result);
	}

	[HttpGet("In/{id}")]
	[Authorize(Policy = "Admin")]
	public async Task<ActionResult> GetByIdWithIncludes(Guid id)
	{
		var cacheData = "GetDelMethodWithIncludesById";

		var result = await _cacheHelper.GetDataFromCache<GetDeliveryWithIncludes>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}

		result = await _deliveryMethodService.GetByIdWithIncludesAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache<GetDeliveryDto>(cacheData, result);

		return Ok(result);
	}

	[HttpPost]
	[Authorize(Policy = "Admin")]
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
	[Authorize(Policy = "Admin")]
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
	[Authorize(Policy = "Admin")]
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
