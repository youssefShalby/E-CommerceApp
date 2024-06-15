


using Stripe;

namespace E_Commerce.BLL.Services;

public class PaymentService : IPaymentService
{
	private readonly StripeSettings _stripeSettings;
	private readonly IBasketService _basketService;
	private readonly IUnitOfWork _unitOfWork;
	public PaymentService(IUnitOfWork unitOfWork, StripeSettings stripeSettings, IBasketService basketService)
	{
		_unitOfWork = unitOfWork;
		_stripeSettings = stripeSettings;
		_basketService = basketService;

	}

	public async Task<CustomerBasket> CreateOrUpdatePaymentIntentAsync(string basketId)
	{
		//> get the secret key of the payment Api from configuration
		StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
		var basket = await _basketService.GetBasketAsync(basketId);

		//> get the shipment price
		decimal shipePrice = 0m;
		if (basket.DeliveryMethodId.HasValue)
		{
			var deliveryMethod = await _unitOfWork.DeliveryMethodRepo.GetByIdAsync(basket.DeliveryMethodId);
			shipePrice = deliveryMethod.Price;

		}

		//> ensure the price of basket matches the original price
		foreach (var item in basket.Items)
		{
			var productItem = await _unitOfWork.ProductRepo.GetByIdAsync(item.Id);
			if (item.Price != productItem.OfferPrice)
			{
				item.Price = productItem.OfferPrice;
			}
		}

		//> initial the paymentService to create and update
		var paymentIntentService = new PaymentIntentService();
		PaymentIntent intent = default!;

		//> if the [PaymentIntentId] is null, so there is no payment created previously, so create one
		if (string.IsNullOrEmpty(basket.PaymentIntentId))
		{
			var options = new PaymentIntentCreateOptions
			{
				//> payment gateway receives the amount in the expected format (cents) for processing the transaction
				//> to convert 1.50$ to cents will mulitiply * 100 => 1.50 * 100 = 150 cents
				Amount = (long)basket.Items.Sum(I => I.Quantity * (I.Price * 100)) + (long)shipePrice * 100,
				Currency = "USD",
				PaymentMethodTypes = new List<string> { "card" } //> default => card
			};

			//> create the payment by the created options
			intent = await paymentIntentService.CreateAsync(options);

			//> get the [intentId, ClientSecret] from the created paymnet and assign basket model
			basket.PaymentIntentId = intent.Id;
			basket.ClientSecret = intent.ClientSecret;
		}
		else
		{
			//> if the [PaymentIntentId] is not null, so there is payment created previously, so update it
			var options = new PaymentIntentUpdateOptions
			{
				Amount = (long)basket.Items.Sum(I => I.Quantity * (I.Price * 100)) + (long)shipePrice * 100,
			};

			//> update by the new options
			await paymentIntentService.UpdateAsync(basket.PaymentIntentId, options);
		}

		//> update the payment options of the basket
		var CustomerBasketDto = new CustomerBasketDto
		{
			PaymentIntentId = basket.PaymentIntentId,
			ClientSecret = basket.ClientSecret,
			DeliveryMethodId = basket.DeliveryMethodId,
			Id = basket.Id,
			Items = basket.Items
		};

		return await _basketService.SetOrUpdateBasketAsync(CustomerBasketDto);
	}

	public async Task<Order> UpdateOrderWhenPaymentFailAsync(string paymentIntentId)
	{
		var order = await _unitOfWork.OrderRepo.GetByPaymentIntentWithIncludesAsync(paymentIntentId);
		if (order is null)
		{
			return null!;
		}

		order.Status = OrderStatus.PaymentFaild;
		await _unitOfWork.OrderRepo.UpdateAsync(order);
		return order;
	}

	public async Task<Order> UpdateOrderWhenPaymentSuccessAsync(string paymentIntentId)
	{
		var order = await _unitOfWork.OrderRepo.GetByPaymentIntentWithIncludesAsync(paymentIntentId);
		if (order is null)
		{
			return null!;
		}

		order.Status = OrderStatus.PaymentReceived;
		await _unitOfWork.OrderRepo.UpdateAsync(order);
		return order;
	}
}
