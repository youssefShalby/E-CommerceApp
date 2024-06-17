

namespace E_Commerce.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IProductService _productService;
	private readonly ICacheHelper _cacheHelper;
    public ProductsController(IProductService productService, ICacheHelper cacheHelper)
    {
        _productService = productService;
		_cacheHelper = cacheHelper;
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
		//> the system support many many products in short time, so we need the system always updated, s we not need caching

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

		var cacheData = "GetAllProductsCreatedByUser";
		var products = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetProductDto>>(cacheData);
		if(products is not null)
		{
			return Ok(products);
		}

		products = await _productService.GetAllCreatedProductsByUserAsync(model);
		if (products is null)
		{
			return NotFound();
		}

		await _cacheHelper.SetDataInCache(userId, products);

		return Ok(products);
	}

	[HttpPost("All/filter")]
	public async Task<ActionResult> GetAllWithFilter([FromBody]ProductQueryHandler queryHandler)
	{

		//> we need short time caching here

		var cacheData = "GetAllProductsWithFilter";
		var products = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetProductDto>>(cacheData);
		if(products is not null)
		{
			return Ok(products);
		}

		products = await _productService.GetAllWithFilterAsync(queryHandler);
		if(products is null)
		{
			return NotFound();
		}

		await _cacheHelper.SetDataInShortTimeCache(cacheData, products);

		return Ok(products);
	}

	[HttpGet("AllIn/{pageNumber}")]
	[Authorize(policy: "User")]
	public async Task<ActionResult> GetAllWithIncludes([FromBody] int pageNumber)
	{
		//> we need short time caching here

		var cacheData = "GetAllProductsWithIncludes";

		var products = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetProductWithIncludesDto>>(cacheData);
		if(products is not null)
		{
			return Ok(products);
		}

		products = await _productService.GetAllWithIncludesAsync(pageNumber, P => P.Brand!, P => P.Category!,  P => P.Images!);
		if (products is null)
		{
			return NotFound();
		}

		await _cacheHelper.SetDataInShortTimeCache(cacheData, products);

		return Ok(products);
	}

	[HttpGet("{id}")]
	[Authorize("Admin")]
	public async Task<ActionResult> GetById(Guid id)
	{
		var cacheData = "GetProductById";
		var product = await _cacheHelper.GetDataFromCache<GetProductDto>(cacheData);
		if(product is not null)
		{
			return Ok(product);
		}

		product = await _productService.GetByIdAsync(id);
		if (product is null)
		{
			return NotFound();
		}

		await _cacheHelper.SetDataInCache(cacheData, product);

		return Ok(product);
	}

	[HttpGet("In/{id}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetByIdWithIncludes(Guid id)
	{
		var cacheData = "GetProductByIdWithIncludes";
		var product = await _cacheHelper.GetDataFromCache<GetProductWithIncludesDto>(cacheData);
		if (product is not null)
		{
			return Ok(product);
		}

		product = await _productService.GetByIdWithIncludesAsync(id);
		if (product is null)
		{
			return NotFound();
		}

		await _cacheHelper.SetDataInCache(cacheData, product);

		return Ok(product);
	}
}
