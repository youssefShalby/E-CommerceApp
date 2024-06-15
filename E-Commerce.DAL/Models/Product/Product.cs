

namespace E_Commerce.DAL.Models;

public class Product : BaseModel<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; }
	public bool IsDeleted { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public decimal OriginalPrice { get; set; }
    public decimal OfferPrice { get; set; }
    public ICollection<Image>? Images { get; set; }

    public Category? Category { get; set; }

    [ForeignKey(nameof(Category))]
    public Guid CategoryId { get; set; }

    public Brand? Brand { get; set; }

    [ForeignKey(nameof(Brand))]
    public Guid BrandId { get; set; }

    public ApplicationUser? User { get; set; }

    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }

}
