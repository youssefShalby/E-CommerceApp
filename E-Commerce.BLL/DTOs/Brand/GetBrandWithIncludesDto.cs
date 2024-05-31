
namespace E_Commerce.BLL.DTOs;

public class GetBrandWithIncludesDto : GetCategoryDto
{
	public ICollection<GetProductDto>? Products { get; set; }
}
