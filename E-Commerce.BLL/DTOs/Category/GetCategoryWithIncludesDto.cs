
namespace E_Commerce.BLL.DTOs;

public class GetCategoryWithIncludesDto : GetCategoryDto
{
	public ICollection<GetProductDto>? Products { get; set; }
}
