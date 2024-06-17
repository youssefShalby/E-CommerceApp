
namespace E_Commerce.DAL.Repositories;

public interface IGenericRepo<T> where T : class
{
	Task<T> GetByIdAsync<Id>(Id id);
	Task<IReadOnlyList<T>> GetAllAsync(int page);
	IEnumerable<T> GetAll(int page);
	Task<IReadOnlyList<T>> GetAllWithIncludesAsync(int page, params Expression<Func<T, object>> [] includes);
	Task CreateAsync(T entity);
	Task CreateWithRangAsync(IEnumerable<T> entity);
	void Update(T entity);
	Task DeleteAsync<Id>(Id id);
	Task<int> SaveChangesAsync();
	int SaveChanges();
	
}
