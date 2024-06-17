

namespace E_Commerce.DAL.Repositories;

public interface IProductRepo : IGenericRepo<Product>
{
	Task<Product> GetByIdWithIncludesAsync(Guid id);
	Task<IEnumerable<Product>> GetAllWithQueryAsync(ProductQueryHandler handler);
	Task<IEnumerable<Product>> GetAllCreatedProductsByUserAsync(string userId, int pageNumber);
	int GetCount();
}
