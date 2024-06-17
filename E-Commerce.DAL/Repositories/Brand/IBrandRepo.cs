
namespace E_Commerce.DAL.Repositories;

public interface IBrandRepo : IGenericRepo<Brand>
{
	Task<Brand> GetByIdWithIncludesAsync(Guid id);
	Task<IReadOnlyList<Brand>> GetAllExceptDeletedAsync(int page);

	Task<IEnumerable<Brand>> GetAllWithQueryAsync(BrandQueryHandler queryHandler);
	Task<int> MarkBrandAsDeletedAsync(Guid id);
	int GetCount();
	int GetDeletedCount();
}
