
namespace E_Commerce.DAL.Repositories;

public interface IBrandRepo : IGenericRepo<Brand>
{
	Task<Brand> GetByIdWithIncludesAsync(Guid id);
	Task<IEnumerable<Brand>> GetAllWithQueryAsync(BrandQueryHandler queryHandler);
}
