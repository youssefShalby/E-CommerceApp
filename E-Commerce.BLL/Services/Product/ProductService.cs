
namespace E_Commerce.BLL.Services;

public class ProductService : IProductService
{
	private readonly IUnitOfWork _unitOfWork;
    public ProductService(IUnitOfWork unitOfWork)
    {
		_unitOfWork = unitOfWork;
    }

    public async Task<CommonResponse> CreateProductAsync(AddProductDto model)
	{
        try
        {
			Product newProduct = ProductMapper.ToProductModelFromCreateDto(model);

			await _unitOfWork.ProductRepo.CreateAsync(newProduct);
			await _unitOfWork.ProductRepo.SaveChangesAsync();
			return new CommonResponse("product created..!!", true);
		}
		catch (Exception ex)
		{
			return new CommonResponse($"cannot create product and reason: {ex.Message}", false);
		}
	}

	public async Task<CommonResponse> DeleteProductAsync(Guid id)
	{
		var productToDelete = await _unitOfWork.ProductRepo.GetByIdWithIncludesAsync(id);
		if (productToDelete is null)
		{
			return new CommonResponse("Product not founded..!!", false);
		}
		try
		{
			await _unitOfWork.ProductRepo.DeleteAsync(id);
			await _unitOfWork.ProductRepo.SaveChangesAsync();
			return new CommonResponse("Product Deleted..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"cannot delete the product right now, reason: {ex.Message}", false);
		}
	}

	public async Task<IReadOnlyList<GetProductDto>> GetAllAsync(int page)
	{
		var products = await _unitOfWork.ProductRepo.GetAllAsync(page);
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
		var products = await _unitOfWork.ProductRepo.GetAllCreatedProductsByUserAsync(model.UserId, model.PageNumber);
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
		var products = await _unitOfWork.ProductRepo.GetAllWithQueryAsync(queryHandler);
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
		var products = await _unitOfWork.ProductRepo.GetAllWithIncludesAsync(page, includes);
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
		var product = await _unitOfWork.ProductRepo.GetByIdAsync(id);
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
		var product = await _unitOfWork.ProductRepo.GetByIdWithIncludesAsync(id);
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

	public int GetCount()
	{
		return _unitOfWork.ProductRepo.GetCount();
	}

	public async Task<CommonResponse> UpdateAsync(Guid id, UpdateProductDto model)
	{
		var productToUpdate = await _unitOfWork.ProductRepo.GetByIdWithIncludesAsync(id);
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

			productToUpdate.Images!.Clear();
			var images = model.ImagesUrl.Select(img => new Image
			{
				Id = Guid.NewGuid(),
				Url = img,
				ProductId = productToUpdate.Id,

			}).ToList();

			await _unitOfWork.ImageRepo.CreateWithRangAsync(images);

			_unitOfWork.ProductRepo.Update(productToUpdate);
			_unitOfWork.ProductRepo.SaveChanges();
			return new CommonResponse("product updated success..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"Cannot Update Product Right Now: reason {ex.Message}", false);
		}
	}

	
}
