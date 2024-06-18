

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
	private readonly IOrderService _orderService;
	private readonly ICacheHelper _cacheHelper;
    public OrdersController(IOrderService orderService, ICacheHelper cacheHelper)
    {
        _orderService = orderService;
		_cacheHelper = cacheHelper;
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

    [HttpGet("GetAll/{pageNumber}")]
	[Authorize(policy: "Admin")]
    public async Task<ActionResult> GetAll(int pageNumber)
    {

		//> the system support many many orders in short time, so we need the system always updated
		var result = await _orderService.GetAllAsync(pageNumber, O => O.OrderItems!, O => O.DeliveryMethod!);
        if(result is null)
        {
            return BadRequest(new ApiResponse(400));
        }

        return Ok(result);
    }

	[HttpGet("GetAllUserOrders/{pageNumber}")]
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

		var cacheData = "GetAllOrdersForUser";

		var result = await _cacheHelper.GetDataFromCache<IReadOnlyList<GetOrderDto>>(cacheData);
		if(result is not null)
		{
			return Ok(result);
		}

		result = await _orderService.GetAllCreatedOrdersByUserAsync(model);
		if (result is null)
		{
			return BadRequest(new ApiResponse(400));
		}

		await _cacheHelper.SetDataInCache(cacheData, result);

		return Ok(result);
	}

	[HttpPost("GetAllWithQuery")]
	[Authorize(policy: "Admin")]
	public async Task<ActionResult> GetAllWithFilter(OrderQueryHandler queryHandler)
    {
		//> the system support many many orders in short time, so we need the system always updated
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
		var cacheData = "GetOrderById";

		var result = await _cacheHelper.GetDataFromCache<GetOrderDto>(cacheData);
		if(result is not null)
		{
			return Ok(result);
		}

		result = await _orderService.GetOrderAsync(id);
		if (result is null)
		{
			return BadRequest(new ApiResponse(400));
		}

		await _cacheHelper.SetDataInCache<GetOrderDto>(cacheData, result);

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
