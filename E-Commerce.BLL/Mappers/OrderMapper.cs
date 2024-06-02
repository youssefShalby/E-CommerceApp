

namespace E_Commerce.BLL.Mappers;

public class OrderMapper
{
	public static GetOrderDto ToGetDto(Order newOrder)
	{
		return new GetOrderDto
		{
			BuyerEmail = newOrder.BuyerEmail,
			OrderDate = newOrder.OrderDate,
			ShipToAddress = newOrder.ShipToAddress,
			DeliveryMethodName = newOrder.DeliveryMethod?.ShortName ?? "NA",
			ShipPrice = newOrder.DeliveryMethod?.Price ?? 0,
			OrderItems = newOrder.OrderItems!.Select(orderItem => new GetOrderItemDto
			{
				Name = orderItem.ItemOrdered?.ProductName ?? "NA",
				ImageUrl = orderItem.ItemOrdered?.ImageUrl ?? "NA",
				Price = orderItem.Price,
				Quantity = orderItem.Quantity

			}).ToList(),

			SubTotalPrice = newOrder.TotalPrice - newOrder.DeliveryMethod?.Price ?? 0,
			TotalPrice = newOrder.TotalPrice,
			Status = newOrder.Status.ToString() ?? "NA"
		};
	}
}
