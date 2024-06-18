

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
	private readonly ICategoryService _categoryService;
	private readonly ICacheHelper _cacheHelper;
    public CategoriesController(ICategoryService categoryService, ICacheHelper cacheHelper)
    {
        _categoryService = categoryService;
		_cacheHelper = cacheHelper;
    }

	[HttpGet("GetAll/{pageNumber}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetAll(int pageNumber)
	{
		var cacheData = "GetAllCategories";

		var result = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetCategoryDto>>(cacheData);
		if(result is not null)
		{
			return Ok(result);
		}

		result = await _categoryService.GetAllAsync(pageNumber);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache(cacheData, result);

		return Ok(result);
	}

	[HttpPost("GetAllWithQuery")]
	public async Task<ActionResult> GetAllWithFilter(CategoryQueryHandler queryHandler)
	{
		var cacheData = "GetAllCategoriesWithFilter";

		var result = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetCategoryDto>>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}

		result = await _categoryService.GetAllWithFilterAsync(queryHandler);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache(cacheData, result);

		return Ok(result);
	}

	[HttpGet("GetAllWithRelatedResources/{pageNumber}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetAllWithIncludes(int pageNumber)
	{
		var cacheData = "GetAllCategoriesWithIncludes";

		var result = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetCategoryWithIncludesDto>>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}

		result = await _categoryService.GetAllWithIncludesAsync(pageNumber, C => C.Products);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache(cacheData, result);

		return Ok(result);
	}

	[HttpGet("GetAllExceptDeleted/{pageNumber}")]
	public async Task<ActionResult> GetAllExceptDeleted(int pageNumber)
	{
		var cacheData = "GetAllCatExceptDeleted";

		var result = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetCategoryWithIncludesDto>>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}

		result = await _categoryService.GetAllWithIncludesExceptDeletedAsync(pageNumber);
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
		var cacheData = "GetCayegoryById";

		var result = await _cacheHelper.GetDataFromCache<GetCategoryDto>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}

		result = await _categoryService.GetByIdAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache<GetCategoryDto>(cacheData, result);

		return Ok(result);
	}

	[HttpGet("GetByIdWithRelatedResources/{id}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetByIdWithIncludes(Guid id)
	{
		var cacheData = "GetCategoryByIdWithIncludes";

		var result = await _cacheHelper.GetDataFromCache<GetCategoryDto>(cacheData);
		if (result is not null)
		{
			return Ok(result);
		}

		result = await _categoryService.GetByIdWithIncludesAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}

		await _cacheHelper.SetDataInCache(cacheData, result);

		return Ok(result);
	}

	[HttpPost]
	[Authorize]
	public async Task<ActionResult> CreateCategory(CreateCategoryDto model)
	{
		var result = await _categoryService.CreateAsync(model);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

	[HttpPut("{id}")]
	[Authorize]
	public async Task<ActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryDto model)
	{
		var result = await _categoryService.UpdateAsync(id, model);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

	[HttpDelete("{id}")]
	[Authorize]
	public async Task<ActionResult> DeleteCategory([FromRoute] Guid id)
	{
		var result = await _categoryService.DeleteAsync(id);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

	[HttpDelete("MarkAsDeleted/{id}")]
	[Authorize]
	public async Task<ActionResult> MarkAsDeleted([FromRoute] Guid id)
	{
		var result = await _categoryService.MarkeCategoryAsDeletedAsync(id);
		if (!result.IsSuccessed)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}
}
