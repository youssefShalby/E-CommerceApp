

namespace E_Commerce.BLL.Services;

public class ProductService : IProductService
{
	private readonly IProductRepo _productRepo;
    public ProductService(IProductRepo productRepo)
    {
		_productRepo = productRepo;
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
}
