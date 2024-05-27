
namespace E_Commerce.DAL.Repositories;

public interface IGenericRepo<T> where T : class
{
	Task<T> GetByIdAsync<TId>(TId id);
	Task<IReadOnlyList<T>> GetAllAsync(int page);
	IEnumerable<T> GetAll(int page);
	Task<IReadOnlyList<T>> GetAllWithIncludes(int page, params Expression<Func<T, object>> [] includes);
	Task CreateAsync(T entity);
	Task UpdateAsync<TId>(TId id, T entity);
	void Update(T entity);
	
	void Delete(T entity);

	Task<int> SaveChangesAsync();
	int SaveChanges();
	
}
