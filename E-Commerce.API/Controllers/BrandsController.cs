﻿

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
	private readonly IBrandService _brandService;
    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet("All")]
    public async Task<ActionResult> GetAll(int page)
    {
        var result = await _brandService.GetAllAsync(page);
        if(result is null)
        {
            return BadRequest(new ApiResponse(404));
        }
        return Ok(result);
    }

	[HttpGet("In/All")]
	public async Task<ActionResult> GetAllWithIncludes(int page)
	{
		var result = await _brandService.GetAllWithIncludes(page, B => B.Products);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

    [HttpGet("{id}")]
	public async Task<ActionResult> GetById(Guid id)
	{
		var result = await _brandService.GetByIdAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

	[HttpGet("In/{id}")]
	public async Task<ActionResult> GetByIdWithIncludes(Guid id)
	{
		var result = await _brandService.GetByIdWithIncludes(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(404));
		}
		return Ok(result);
	}

	[HttpPost]
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
