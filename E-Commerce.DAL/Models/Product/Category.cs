
namespace E_Commerce.DAL.Models;

public class Category : BaseModel<Guid>
{
    public string Name { get; set; } = string.Empty;
	public bool IsDeleted { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public ICollection<Product> Products { get; set; }
    public Category()
    {
        Products = new HashSet<Product>();
    }
}
