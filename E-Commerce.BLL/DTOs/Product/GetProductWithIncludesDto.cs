

namespace E_Commerce.BLL.DTOs;

public class GetProductWithIncludesDto : GetProductDto
{
	public string CategoryName { get; set; } = string.Empty;
	public string BrandName { get; set; } = string.Empty;
    public IEnumerable<string>? ImagesUrl { get; set; }
}
