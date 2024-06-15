
namespace E_Commerce.BLL.Mappers;

//> i'm not a big fan for automapper
public class ProductMapper
{
	public static GetProductWithIncludesDto ToGetWithIncludesDto(Product product)
	{
		return new GetProductWithIncludesDto
		{
			Name = product.Name,
			Description = product.Description,
			Stock = product.Stock,
			OriginalPrice = product.OriginalPrice,
			OfferPrice = product.OfferPrice,
			CreatedAt = product.CreatedAt,
			BrandName = product.Brand?.Name ?? "NA",
			CategoryName = product.Category?.Name ?? "NA",
			ImagesUrl = product.Images.Select(img => img.Url).ToList()
		};
	}

	public static GetProductDto ToGetDto(Product product)
	{
		return new GetProductDto
		{
			Name = product.Name,
			Description = product.Description,
			Stock = product.Stock,
			OriginalPrice = product.OriginalPrice,
			OfferPrice = product.OfferPrice,
			CreatedAt = product.CreatedAt,
		};
	}

	public static Product ToProductModelFromCreateDto(AddProductDto model)
	{
		Product newProduct = new Product
		{
			Id = Guid.NewGuid(),
			Name = model.Name,
			Description = model.Description,
			Stock = model.Stock,
			OriginalPrice = model.OriginalPrice,
			OfferPrice = model.OfferPrice,
			CategoryId = model.CategoryId,
			BrandId = model.BrandId,
			CreatedAt = model.CreatedAt,
			UserId = model.UserId,
		};

		newProduct.Images = model.ImagesUrl.Select(img => new Image
		{
			Id = Guid.NewGuid(),
			Url = img,
			ProductId = newProduct.Id

		}).ToList();

		return newProduct;
	}
}
