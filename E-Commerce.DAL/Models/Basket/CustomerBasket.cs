
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
}
