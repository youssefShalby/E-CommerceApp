
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
    public async Task<ActionResult> CreateProduct(AddProductDto model)
    {
        var result = await _productService.CreateProductAsync(model);
        if (!result.IsSuccessed)
        {
            return BadRequest(result);
        }
        return StatusCode(201, result);
    }

    [HttpGet("All/{pageNumber}")]
    public async Task<ActionResult> GetAll(int pageNumber)
    {
        var products = await _productService.GetAllAsync(pageNumber);
        if(products is null)
        {
            return NotFound();
        }

        return Ok(products);
    }

	[HttpGet("AllIn/{pageNumber}")]
	public async Task<ActionResult> GetAllWithIncludes([FromRoute]int pageNumber)
	{
		var products = await _productService.GetAllWithIncludesAsync(pageNumber, P => P.Brand!, P => P.Category!);
		if (products is null)
		{
			return NotFound();
		}

		return Ok(products);
	}

	[HttpGet("{id}")]
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
