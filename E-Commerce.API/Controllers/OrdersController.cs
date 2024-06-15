

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
	[Authorize]
    public async Task<ActionResult> CreateOrder(CreateOrderDto model)
    {
        var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value ?? "NA";
		if(userEmail == "NA")
		{
			return BadRequest("there is wrong..!!");
		}

		model.BuyerEmail = userEmail;

        var order = await _orderService.CreateOrderAsync(model);
        if(order is null)
        {
            return BadRequest(new ApiResponse(400));
        }

        return Ok(order);
    }

    [HttpGet("All/{pageNumber}")]
	[Authorize(policy: "Admin")]
    public async Task<ActionResult> GetAll(int pageNumber)
    {
        var result = await _orderService.GetAllAsync(pageNumber, O => O.OrderItems!, O => O.DeliveryMethod!);
        if(result is null)
        {
            return BadRequest(new ApiResponse(400));
        }

        return Ok(result);
    }

	[HttpGet("All/User/{pageNumber}")]
	[Authorize]
	public async Task<ActionResult> GetAllCreatedByUser(int pageNumber)
	{
		var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value ?? "NA";
		if (userEmail == "NA")
		{
			return BadRequest("there is wrong..!!");
		}

		GetCreatedOrdersByUser model = new GetCreatedOrdersByUser
		{
			PageNumber = pageNumber,
			UserEmail = userEmail
		};

		var result = await _orderService.GetAllCreatedOrdersByUserAsync(model);
		if (result is null)
		{
			return BadRequest(new ApiResponse(400));
		}

		return Ok(result);
	}

	[HttpPost("All/filter")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetAllWithFilter(OrderQueryHandler queryHandler)
    {
        var result = await _orderService.GetAllWithFilterAsync(queryHandler);
        if(result is null)
        {
            return BadRequest(new ApiResponse(400));
        }

        return Ok(result);
    }

	[HttpGet("{id}")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetById(Guid id)
	{
		var result = await _orderService.GetOrderAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(400));
		}

		return Ok(result);
	}

	[HttpPut("{id}")]
	[Authorize]
	public async Task<ActionResult> UpdateOrder(Guid id, UpdateOrderDto model)
	{
		var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value ?? "NA";
		if (userEmail == "NA")
		{
			return BadRequest("there is wrong..!!");
		}

		model.BuyerEmail = userEmail;

		var result = await _orderService.UpdateAsync(id, model);
		if (!result.IsSuccessed)
		{
			return BadRequest(new ApiResponse(400, result.Message));
		}

		return Ok(result);
	}

	[HttpDelete("{id}")]
	[Authorize]
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
