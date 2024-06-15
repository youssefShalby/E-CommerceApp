

namespace E_Commerce.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
	[Authorize]
    public async Task<ActionResult> CreateProduct(AddProductDto model)
    {
		var userId = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.NameIdentifier)?.Value ?? "NA";
		if(userId == "NA")
		{
			return BadRequest("there is wrong..!!");
		}

		model.UserId = userId;

        var result = await _productService.CreateProductAsync(model);
        if (!result.IsSuccessed)
        {
            return BadRequest(result);
        }
        return StatusCode(201, result);
    }

	[HttpPut("{id}")]
	[Authorize]
	public async Task<ActionResult> UpdateProduct([FromRoute]Guid id, [FromBody]UpdateProductDto model)
	{
		var result = await _productService.UpdateAsync(id, model);
		if (!result.IsSuccessed)
		{
			return BadRequest(new ApiResponse(401, result.Message));
		}
		return Ok(result);
	}

	[HttpDelete("{id}")]
	[Authorize]
	public async Task<ActionResult> DeleteProduct([FromRoute] Guid id)
	{
		var result = await _productService.DeleteProductAsync(id);
		if (!result.IsSuccessed)
		{
			return BadRequest(new ApiResponse(401, result.Message));
		}
		return Ok(result);
	}

	[HttpGet("All/{pageNumber}")]
	[Authorize(policy: "Admin")]
    public async Task<ActionResult> GetAll(int pageNumber)
    {
        var products = await _productService.GetAllAsync(pageNumber);
        if(products is null)
        {
            return NotFound();
        }

        return Ok(products);
    }

	[HttpGet("All/User/{pageNumber}")]
	[Authorize(policy: "User")]
	public async Task<ActionResult> GetAllCreatedByUser(int pageNumber)
	{
		var userId = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.NameIdentifier)?.Value ?? "NA";
		if(userId == "NA")
		{
			return BadRequest("there is wrong..!!");
		}

		GetCreatedProductByUser model = new GetCreatedProductByUser
		{
			PageNumber = pageNumber,
			UserId = userId
		};

		var products = await _productService.GetAllCreatedProductsByUserAsync(model);
		if (products is null)
		{
			return NotFound();
		}

		return Ok(products);
	}

	[HttpPost("All/filter")]
	public async Task<ActionResult> GetAllWithFilter([FromBody]ProductQueryHandler queryHandler)
	{
		var products = await _productService.GetAllWithFilterAsync(queryHandler);
		if(products is null)
		{
			return NotFound();
		}

		return Ok(products);
	}

	[HttpGet("AllIn/{pageNumber}")]
	[Authorize(policy: "User")]
	public async Task<ActionResult> GetAllWithIncludes([FromBody] int pageNumber)
	{
		var products = await _productService.GetAllWithIncludesAsync(pageNumber, P => P.Brand!, P => P.Category!,  P => P.Images);
		if (products is null)
		{
			return NotFound();
		}

		return Ok(products);
	}

	[HttpGet("{id}")]
	[Authorize("Admin")]
	public async Task<ActionResult> GetById(Guid id)
	{
		var product = await _productService.GetByIdAsync(id);
		if (product is null)
		{
			return NotFound();
		}

		return Ok(product);
	}

	[HttpGet("In/{id}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetByIdWithIncludes(Guid id)
	{
		var product = await _productService.GetByIdWithIncludesAsync(id);
		if (product is null)
		{
			return NotFound();
		}

		return Ok(product);
	}
}
