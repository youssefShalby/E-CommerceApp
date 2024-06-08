namespace E_Commerce.BLL.DTOs;

public class CustomerBasketDto
{
    public string Id { get; set; } = string.Empty;
	public Guid? DeliveryMethodId { get; set; }
	public string ClientSecret { get; set; } = string.Empty;
	public string PaymentIntentId { get; set; } = string.Empty;
	public ICollection<BasketItem>? Items { get; set; }
}
