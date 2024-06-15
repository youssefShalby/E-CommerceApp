

namespace E_Commerce.BLL.Services;

public interface IProductService
{
	Task<CommonResponse> CreateProductAsync(AddProductDto model);
	Task<GetProductDto> GetByIdAsync(Guid id);
	Task<IReadOnlyList<GetProductDto>> GetAllAsync(int page);
	Task<IReadOnlyList<GetProductDto>> GetAllCreatedProductsByUserAsync(GetCreatedProductByUser model);
	Task<IReadOnlyList<GetProductDto>> GetAllWithFilterAsync(ProductQueryHandler queryHandler);

	Task<IReadOnlyList<GetProductWithIncludesDto>> GetAllWithIncludesAsync(int page, params Expression<Func<Product, object>>[] includes);
	Task<GetProductWithIncludesDto> GetByIdWithIncludesAsync(Guid id);
	Task<CommonResponse> UpdateAsync(Guid id, UpdateProductDto model);
	Task<CommonResponse> DeleteProductAsync(Guid id);
}

