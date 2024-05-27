
namespace E_Commerce.DAL.Models;

public class Image:BaseModel<Guid>
{
    public string Url { get; set; } = string.Empty;
    public Guid ProductId { get; set; }
}
