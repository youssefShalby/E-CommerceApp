

using MailKit.Net.Imap;

namespace E_Commerce.BLL.Services;

public class ProductService : IProductService
{
	private readonly IProductRepo _productRepo;
	private readonly IImageRepo _imageRepo;
    public ProductService(IProductRepo productRepo, IImageRepo imageRepo)
    {
		_productRepo = productRepo;
		_imageRepo = imageRepo;
    }

    public async Task<CommonResponse> CreateProductAsync(AddProductDto model)
	{
        try
        {
			Product newProduct = ProductMapper.ToProductModelFromCreateDto(model);

			await _productRepo.CreateAsync(newProduct);
			return new CommonResponse("product created..!!", true);
		}
		catch (Exception ex)
		{
			return new CommonResponse($"cannot create product and reason: {ex.Message}", false);
		}
	}

	public async Task<CommonResponse> DeleteProductAsync(Guid id)
	{
		var productToDelete = await _productRepo.GetByIdWithIncludesAsync(id);
		if (productToDelete is null)
		{
			return new CommonResponse("Product not founded..!!", false);
		}
		try
		{
			await _productRepo.DeleteAsync(id);
			return new CommonResponse("Product Deleted..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"cannot delete the product right now, reason: {ex.Message}", false);
		}
	}

	public async Task<IReadOnlyList<GetProductDto>> GetAllAsync(int page)
	{
		var products = await _productRepo.GetAllAsync(page);
		if(products is null)
		{
			return null!;
		}

		try
		{
			return products.Select(product => ProductMapper.ToGetDto(product)).ToList();
		}
		catch(Exception)
		{
			return null!;
		}
	}

	public async Task<IReadOnlyList<GetProductDto>> GetAllCreatedProductsByUserAsync(GetCreatedProductByUser model)
	{
		var products = await _productRepo.GetAllCreatedProductsByUserAsync(model.UserId, model.PageNumber);
		if (products is null)
		{
			return null!;
		}

		try
		{
			return products.Select(product => ProductMapper.ToGetDto(product)).ToList();
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<IReadOnlyList<GetProductDto>> GetAllWithFilterAsync(ProductQueryHandler queryHandler)
	{
		var products = await _productRepo.GetAllWithQueryAsync(queryHandler);
		if (products is null)
		{
			return null!;
		}

		try
		{
			return products.Select(product => ProductMapper.ToGetDto(product)).ToList();
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<IReadOnlyList<GetProductWithIncludesDto>> GetAllWithIncludesAsync(int page, params Expression<Func<Product, object>>[] includes)
	{
		var products = await _productRepo.GetAllWithIncludesAsync(page, includes);
		if(products is null)
		{
			return null!;
		}

		try
		{
			return products.Select(product => ProductMapper.ToGetWithIncludesDto(product)).ToList();
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<GetProductDto> GetByIdAsync(Guid id)
	{
		var product = await _productRepo.GetByIdAsync(id);
		if(product is null)
		{
			return null!;
		}

		try
		{
			return ProductMapper.ToGetDto(product);
		}
		catch(Exception)
		{
			return null!;
		}
	}

	public async Task<GetProductWithIncludesDto> GetByIdWithIncludesAsync(Guid id)
	{
		var product = await _productRepo.GetByIdWithIncludesAsync(id);
		if(product is null)
		{
			return null!;
		}
		try
		{
			return ProductMapper.ToGetWithIncludesDto(product);
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<CommonResponse> UpdateAsync(Guid id, UpdateProductDto model)
	{
		var productToUpdate = await _productRepo.GetByIdWithIncludesAsync(id);
		if(productToUpdate is null)
		{
			return new CommonResponse("Product not founded..!!", false);
		}

		try
		{
			productToUpdate.Name = model.Name;
			productToUpdate.Description = model.Description;
			productToUpdate.OfferPrice = model.OfferPrice;
			productToUpdate.OriginalPrice = model.OriginalPrice;
			productToUpdate.Stock = model.Stock;
			productToUpdate.BrandId = model.BrandId;
			productToUpdate.CategoryId = model.CategoryId;

			productToUpdate.Images.Clear();
			var images = model.ImagesUrl.Select(img => new Image
			{
				Id = Guid.NewGuid(),
				Url = img,
				ProductId = productToUpdate.Id,

			}).ToList();

			await _imageRepo.CreateWithRangAsync(images);

			_productRepo.Update(productToUpdate);
			return new CommonResponse("product updated success..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"Cannot Update Product Right Now: reason {ex.Message}", false);
		}
	}

	
}
