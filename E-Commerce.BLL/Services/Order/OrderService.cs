
using StackExchange.Redis;

namespace E_Commerce.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBasketService _basketService;
    private readonly IPaymentService _paymentService;
    public OrderService(IUnitOfWork unitOfWork, IBasketService basketService, IPaymentService paymentService)
    {
        _unitOfWork = unitOfWork;
        _basketService = basketService;
        _paymentService = paymentService;
    }

    public async Task<GetOrderDto> CreateOrderAsync(CreateOrderDto model)
	{
        //> get the basket
        var basket = await _basketService.GetBasketAsync(model.BasketId);

        if(basket is null)
        {
            return null!;
        }

        //> get the Items from the Basket
        var Items = await GetOrderItemsFromBasket(basket.Items);

        //> calculate the total prie, iterates on each item and calc [sum * quantity]
        decimal subTotalPrice = Items.Sum(I => I.Price * I.Quantity);

		//> get the price of the Shipment
		var deliverMethod = await _unitOfWork.DeliveryMethodRepo.GetByIdAsync(model.DeliveryMethodId);
		decimal totalPrice = subTotalPrice + deliverMethod.Price;

		//> check if there is order exist with paymentIntent or not
		var existingOrder = await _unitOfWork.OrderRepo.GetByPaymentIntentWithIncludesAsync(basket.PaymentIntentId);
        if(existingOrder is not null)
        {
            //> update it
            var orderToUpdate = new UpdateOrderDto
            {
                BasketId = model.BasketId,
                BuyerEmail = model.BuyerEmail,
                DeliveryMethodId = model.DeliveryMethodId,
                ShipToAddress = model.ShipmentAddress,
			};

            var result = await UpdateAsync(existingOrder.Id, orderToUpdate);

            return result.IsSuccessed ? OrderMapper.ToGetDto(existingOrder) : null!;
        }
        else
        {
			//> create the order
			Order newOrder = new Order
			{
				BuyerEmail = model.BuyerEmail,
				OrderItems = Items,
				TotalPrice = totalPrice,
				DeliveryMethodId = model.DeliveryMethodId,
				ShipToAddress = model.ShipmentAddress,
				Status = OrderStatus.Pending,
                PaymentIntentId = basket.PaymentIntentId
			};

			//> set the foreign kes of Order to the OrderItem
			foreach (var item in newOrder.OrderItems)
			{
				item.OrderId = newOrder.Id;
			}

			//> save the order to Db
			await _unitOfWork.OrderRepo.CreateAsync(newOrder);

			//> return the details of the Order
			return OrderMapper.ToGetDto(newOrder);
		}
    }

	public async Task<CommonResponse> DeleteAsync(Guid id)
	{
        var orderToDelete = await _unitOfWork.OrderRepo.GetByIdAsync(id);
        if(orderToDelete is null)
        {
            return new CommonResponse("cannot find the order..!!", false);
        }

        if(orderToDelete.Status != OrderStatus.Pending)
        {
            return new CommonResponse("cannot cancel order after received, can only cancel it in 'pending' case..!!", false);
        }

        try
        {
            await _unitOfWork.OrderRepo.DeleteAsync(id);
            return new CommonResponse("order cancelled..!!", true);
        }
        catch(Exception ex)
        {
            return new CommonResponse($"error when deleteing the order, reason: {ex.Message}", false);
        }
	}

	public async Task<IReadOnlyList<GetOrderDto>> GetAllAsync(int page, params Expression<Func<Order, object>>[] includes)
	{
        var orders = await _unitOfWork.OrderRepo.GetAllWithIncludesAsync(page, includes);
        if(orders is null)
        {
            return null!;
        }

        try
        {
            return orders.Select(order => OrderMapper.ToGetDto(order)).ToList();
        }
        catch (Exception)
        {
            return null!;
        }
	}

	public async Task<IReadOnlyList<GetOrderDto>> GetAllCreatedOrdersByUserAsync(GetCreatedOrdersByUser model)
	{
		var orders = await _unitOfWork.OrderRepo.GetAllCreatedOrdersByUserAsync(model.UserEmail, model.PageNumber);
		if (orders is null)
		{
			return null!;
		}

		try
		{
			return orders.Select(order => OrderMapper.ToGetDto(order)).ToList();
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<IReadOnlyList<GetOrderDto>> GetAllWithFilterAsync(OrderQueryHandler queryHandler)
	{
		var orders = await _unitOfWork.OrderRepo.GetAllWithQueryAsync(queryHandler);
		if (orders is null)
		{
			return null!;
		}

		try
		{
			return orders.Select(order => OrderMapper.ToGetDto(order)).ToList();
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<GetOrderDto> GetOrderAsync(Guid id)
	{
        var order = await _unitOfWork.OrderRepo.GetByIdWithIncludesAsync(id);
        if(order is null)
        {
            return null!;
        }
        try
        {
            return OrderMapper.ToGetDto(order);
        }
        catch (Exception)
        {
            return null!;
        }
	}

	public async Task<CommonResponse> UpdateAsync(Guid id, UpdateOrderDto model)
	{
        var orderToUpdate = await _unitOfWork.OrderRepo.GetByIdWithIncludesAsync(id);
        if(orderToUpdate is null)
        {
            return new CommonResponse("cannot find order to update..!!", false);
        }

        if(orderToUpdate.Status != OrderStatus.Pending)
        {
            return new CommonResponse("cannot update order after received, can only update it in 'pending' case..!!", false);
        }

        if(orderToUpdate is null)
        {
            return new CommonResponse("cannot find the Order..!!", false);
        }

        try
        {
            orderToUpdate.BuyerEmail = model.BuyerEmail;
            orderToUpdate.ShipToAddress = model.ShipToAddress;
            orderToUpdate.DeliveryMethodId = model.DeliveryMethodId;
            orderToUpdate.DeliveryMethod = await _unitOfWork.DeliveryMethodRepo.GetByIdAsync(model.DeliveryMethodId);

            //> get order items from new basket
            var basket = await _basketService.GetBasketAsync(model.BasketId);
            if(basket is null)
            {
				return new CommonResponse("cannot update the Order..!!", false);
			}

            orderToUpdate.OrderItems?.Clear();
            var items = await GetOrderItemsFromBasket(basket.Items);

			//> set the foreign kes of Order to the OrderItem
			foreach (var item in items)
			{
				item.OrderId = orderToUpdate.Id;
			}

            //> calculate new total price of the new items
            decimal newTotalPrice = items.Sum(I => I.Price * I.Quantity);
            orderToUpdate.TotalPrice = newTotalPrice + orderToUpdate.DeliveryMethod?.Price ?? 0; ;

			await _unitOfWork.OrderItemRepo.CreateWithRangAsync(items);
			await _unitOfWork.OrderRepo.UpdateAsync(orderToUpdate);

            return new CommonResponse("order updated..!!", true);
        }
        catch(Exception ex)
        {
            return new CommonResponse($"error while updating the order, reason: {ex.Message}", false);
        }
	}

    private async Task<List<OrderItem>> GetOrderItemsFromBasket(ICollection<BasketItem> BasketItems)
    {
		//> get the Items from the Basket
		var Items = new List<OrderItem>();
		foreach (var item in BasketItems)
		{
			//> get each Item of the basket from the db by Id
			var productItem = await _unitOfWork.ProductRepo.GetByIdWithIncludesAsync(item.Id);
			var itemOrdered = new ProductOrderItem
			{
				Id = productItem.Id,
				ImageUrl = productItem.Images.Select(img => img.Url).ToArray()[0],
				ProductName = productItem.Name
			};

			//> create order item
			var orderItem = new OrderItem
			{
				Id = Guid.NewGuid(),
				ItemOrdered = itemOrdered,
				Price = item.Price,
				Quantity = item.Quantity,
			};

			//> add order item
			Items.Add(orderItem);
		}

        return Items;
	}
}
