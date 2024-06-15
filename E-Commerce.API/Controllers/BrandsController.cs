

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
	private readonly IBrandService _brandService;
	private readonly ICacheHelper _cacheHelper;
    public BrandsController(IBrandService brandService, ICacheHelper cacheHelper)
    {
        _brandService = brandService;
		_cacheHelper = cacheHelper;
    }

	[HttpGet("All/{pageNumber}")]
	[Authorize(policy: "Admin")]
    public async Task<ActionResult> GetAll(int pageNumber)
    {
		var cacheData = "GetAllBrands";

		var data = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetBrandDto>>(cacheData);

		if (data is not null)
		{
			return Ok(data);
		}

		//> if data is not in cache, get it and then add it in cache
		data = await _brandService.GetAllAsync(pageNumber);
		if (data is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache(cacheData, data);

		return Ok(data);
    }

	[HttpPost("All/filter")]
	public async Task<ActionResult> GetAllWithFilter(BrandQueryHandler queryHandler)
	{
		var cacheData = "GetAllBrandsWithFilter";

		var result = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetBrandDto>>(cacheData);
		if(result is not null)
		{
			return Ok(result);
		}

		result = await _brandService.GetAllWithFilterAsync(queryHandler);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache(cacheData, result);

		return Ok(result);
	}

	[HttpGet("AllIn/{pageNumber}")]
	public async Task<ActionResult> GetAllWithIncludes(int pageNumber)
	{
		var cacheData = "GetAllBrandsWithIncludes";

		var result = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetBrandWithIncludesDto>>(cacheData);
		if(result is not null)
		{
			return Ok(result);
		}

		result = await _brandService.GetAllWithIncludes(pageNumber, B => B.Products);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache(cacheData, result);

		return Ok(result);
	}

    [HttpGet("{id}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetById(Guid id)
	{
		var cacheData = "GetBrandById";

		var result = await _cacheHelper.GetDataFromCache<GetBrandDto>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}

		result = await _brandService.GetByIdAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache<GetBrandDto>(cacheData, result);

		return Ok(result);
	}

	[HttpGet("In/{id}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetByIdWithIncludes(Guid id)
	{
		var cacheData = "GetBrandByIdWithIncludes";

		var result = await _cacheHelper.GetDataFromCache<GetBrandWithIncludesDto>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}

		result = await _brandService.GetByIdWithIncludes(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache<GetBrandWithIncludesDto>(cacheData, result);

		return Ok(result);
	}

	[HttpPost]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> CreateBrand(CreateBrandDto model)
	{
		var result = await _brandService.CreateAsync(model);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

	[HttpPut("{id}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> UpdateBrand([FromRoute]Guid id, [FromBody]UpdateBrandDto model)
	{
		var result = await _brandService.UpdateAsync(id, model);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

	[HttpDelete("{id}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> DeleteBrand([FromRoute] Guid id)
	{
		var result = await _brandService.DeleteAsync(id);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

}
