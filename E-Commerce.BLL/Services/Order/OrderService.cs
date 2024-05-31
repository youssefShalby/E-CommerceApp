

namespace E_Commerce.BLL.Services;

public class OrderService : IOrderService
{
	private readonly IOrderRepo _orderRepo;
    private readonly IBasketService _basketService;
    private readonly IProductRepo _productRepo;
    public OrderService(IOrderRepo orderRepo, IBasketService basketService, IProductRepo productRepo)
    {
        _orderRepo = orderRepo;
        _basketService = basketService;
        _productRepo = productRepo;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderDto model)
	{
        //> get the basket
        var basket = await _basketService.GetBasketAsync(model.BasketId);

        //> get the Items from the Basket
        var Items = new List<OrderItem>();
        foreach(var item in basket.Items)
        {
            //> get each Item from the db by Id
            var productItem = await _productRepo.GetByIdAsync(item.Id);
            var itemOrdered = new ProductOrderItem
            {
                Id = item.Id,
                ImageUrl = item.ImagesUrl?.ToArray()[0] ?? "NA",
                ProductName = item.ProductName
            };

            //> create order item
            var OrderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                ItemOrdered = itemOrdered,
                Price = item.Price,
                Quantity = item.Quantity,
            };

            //> add order item
            Items.Add(OrderItem);
        }

        return default!;
	}
}
