
namespace E_Commerce.DAL.Repositories;

public interface ICategoryRepo : IGenericRepo<Category>
{
	Task<Category> GetByIdWithIncludesAsync(Guid id);
	Task<IReadOnlyList<Category>> GetAllExceptDeletedAsync(int page);

	Task<IEnumerable<Category>> GetAllWithQueryAsync(CategoryQueryHandler queryHandler);
	Task<int> MarkCategoryAsDeletedAsync(Guid id);

	int GetCount();
	int GetDeletedCount();
}
