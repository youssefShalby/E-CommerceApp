

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
	private readonly IOrderService _orderService;
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(CreateOrderDto model)
    {
        var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email);

        //> TODO: assign the email autmaticallly

        var order = await _orderService.CreateOrderAsync(model);
        if(order is null)
        {
            return BadRequest(new ApiResponse(400));
        }

        return Ok(order);
    }

    [HttpGet("All/{pageNumber}")]
    public async Task<ActionResult> GetAll(int pageNumber)
    {
        var result = await _orderService.GetAllAsync(pageNumber, O => O.OrderItems!, O => O.DeliveryMethod!);
        if(result is null)
        {
            return BadRequest(new ApiResponse(400));
        }

        return Ok(result);
    }

	[HttpGet("{id}")]
	public async Task<ActionResult> GetAll(Guid id)
	{
		var result = await _orderService.GetOrderAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(400));
		}

		return Ok(result);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateOrder(Guid id, UpdateOrderDto model)
	{
		var result = await _orderService.UpdateAsync(id, model);
		if (!result.IsSuccessed)
		{
			return BadRequest(new ApiResponse(400, result.Message));
		}

		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteOrder(Guid id)
	{
		var result = await _orderService.DeleteAsync(id);
		if (!result.IsSuccessed)
		{
			return BadRequest(new ApiResponse(400, result.Message));
		}

		return Ok(result);
	}
}
