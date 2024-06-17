
namespace E_Commerce.DAL.Repositories;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
	private readonly AppDbContext _context;
	private readonly IConfiguration _configuration;
	private readonly IConfigHelper _helper;
    public GenericRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper)
    {
		_context = context;
		_configuration = configuration;
		_helper = helper;
    }

    public async Task CreateAsync(T entity)
	{
		await _context.Set<T>().AddAsync(entity);
	}

	public async Task CreateWithRangAsync(IEnumerable<T> entity)
	{
		await _context.Set<T>().AddRangeAsync(entity);
	}

	public async Task DeleteAsync<TId>(TId id)
	{
		var productToDelete = await GetByIdAsync(id);
		_context.Set<T>().Remove(productToDelete);
	}

	public IEnumerable<T> GetAll(int page)
	{
		return _context.Set<T>().AsNoTracking()
			.Skip((page - 1) * _helper.GetPageSize()).Take(_helper.GetPageSize()).ToList();
	}

	public async Task<IReadOnlyList<T>> GetAllAsync(int page)
	{
		return await _context.Set<T>().AsNoTracking()
			.Skip((page - 1) * _helper.GetPageSize()).Take(_helper.GetPageSize()).ToListAsync();
	}

	public async Task<IReadOnlyList<T>> GetAllWithIncludesAsync(int page, params Expression<Func<T, object>>[] includes)
	{
		var query = _context.Set<T>().AsQueryable();
		foreach(var include in includes)
		{
			query = query.Include(include);
		}
		return await query.Skip((page - 1) * _helper.GetPageSize()).Take(_helper.GetPageSize()).ToListAsync();
	}

	public async Task<T> GetByIdAsync<TId>(TId id)
	{
		return await _context.Set<T>().FindAsync(id) ?? null!;
	}

	public int SaveChanges()
	{
		return _context.SaveChanges();
	}

	public async Task<int> SaveChangesAsync()
	{
		return await _context.SaveChangesAsync();
	}

	public void Update(T entity)
	{
		_context.Set<T>().Update(entity);
	}

	
}
