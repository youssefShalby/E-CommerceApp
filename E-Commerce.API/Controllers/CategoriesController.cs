﻿

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
	private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

	[HttpGet("All/{pageNumber}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetAll(int page)
	{
		var result = await _categoryService.GetAllAsync(page);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

	[HttpPost("All/filter")]
	public async Task<ActionResult> GetAllWithFilter(CategoryQueryHandler queryHandler)
	{
		var result = await _categoryService.GetAllWithFilterAsync(queryHandler);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

	[HttpGet("AllIn/{pageNumber}")]
	public async Task<ActionResult> GetAllWithIncludes(int page)
	{
		var result = await _categoryService.GetAllWithIncludesAsync(page, C => C.Products);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

	[HttpGet("{id}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetById(Guid id)
	{
		var result = await _categoryService.GetByIdAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

	[HttpGet("In/{id}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetByIdWithIncludes(Guid id)
	{
		var result = await _categoryService.GetByIdWithIncludesAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
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
}
