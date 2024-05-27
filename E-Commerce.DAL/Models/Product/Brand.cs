

namespace E_Commerce.DAL.Models;

public class Brand : BaseModel<Guid>
{
	public string Name { get; set; } = string.Empty;
	public bool IsDeleted { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public ICollection<Product> Products { get; set; }
    public Brand()
    {
        Products = new HashSet<Product>();
    }
}
