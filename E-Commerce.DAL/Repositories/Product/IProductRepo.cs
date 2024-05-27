

namespace E_Commerce.DAL.Repositories;

public interface IProductRepo : IGenericRepo<Product>
{
	Task<Product> GetByIdWithIncludesAsync(Guid id);
}
