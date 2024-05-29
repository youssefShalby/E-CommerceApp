
namespace E_Commerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController : ControllerBase
{
    private readonly IBasketService _basketService;
    public BasketsController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetBasketById(string id)
    {
        var basket = await _basketService.GetBasketAsync(id);

        if(basket is null)
        {
            return NotFound("basket not founded..!!");
        }

        return Ok(basket);
    }

    [HttpPost]
    public async Task<ActionResult> UpdateBasket(CustomerBasketDto customerBasket)
    {
        var basket = await _basketService.SetOrUpdateBasketAsync(customerBasket);
        return StatusCode(201, basket);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBasket(string id)
    {
        var deleted = await _basketService.RmoveBasketAsync(id);
        if(deleted)
        {
			return Ok("deleted..!!");
		}
        return BadRequest("the basket is not exist...!!");
    }
}
