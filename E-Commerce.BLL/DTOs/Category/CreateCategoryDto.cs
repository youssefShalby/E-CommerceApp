

namespace E_Commerce.BLL.DTOs;

public class CreateCategoryDto
{
    public string Name { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; } = DateTime.Now;
}
