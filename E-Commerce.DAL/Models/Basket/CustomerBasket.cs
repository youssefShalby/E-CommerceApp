
namespace E_Commerce.DAL.Models;

public class CustomerBasket : BaseModel<string>
{

    public CustomerBasket()
    {
        
    }
    public CustomerBasket(string BasketId)
    {
        Id = BasketId;
    }
    public ICollection<BasketItem> Items { get; set; } = new HashSet<BasketItem>();
	public Guid? DeliveryMethodId { get; set; }
	public string ClientSecret { get; set; } = string.Empty;
	public string PaymentIntentId { get; set; } = string.Empty;
}
