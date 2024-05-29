namespace E_Commerce.BLL.DTOs;

public class CustomerBasketDto
{
    public string Id { get; set; } = string.Empty;
    public ICollection<BasketItem>? Items { get; set; }
}
