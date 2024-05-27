﻿
namespace E_Commerce.DAL.Repositories;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
	private readonly AppDbContext _context;
	private readonly IConfiguration _configuration;
    public GenericRepo(AppDbContext context, IConfiguration configuration)
    {
		_context = context;
		_configuration = configuration;
    }

    public async Task CreateAsync(T entity)
	{
		await _context.Set<T>().AddAsync(entity);
		await SaveChangesAsync();
	}

	public void Delete(T entity)
	{
		_context.Set<T>().Remove(entity);
		SaveChanges();
	}

	public IEnumerable<T> GetAll(int page)
	{
		return _context.Set<T>().AsNoTracking()
			.Skip((page - 1) * GetPageSize()).Take(GetPageSize()).ToList();
	}

	public async Task<IReadOnlyList<T>> GetAllAsync(int page)
	{
		return await _context.Set<T>().AsNoTracking()
			.Skip((page - 1) * GetPageSize()).Take(GetPageSize()).ToListAsync();
	}

	public async Task<IReadOnlyList<T>> GetAllWithIncludesAsync(int page, params Expression<Func<T, object>>[] includes)
	{
		var query = _context.Set<T>().AsQueryable();
		foreach(var include in includes)
		{
			query = query.Include(include);
		}
		return await query.Skip((page - 1) * GetPageSize()).Take(GetPageSize()).ToListAsync();
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
		SaveChanges();
	}

	public async Task UpdateAsync<TId>(TId id, T entity)
	{
		var originalEntity = await GetByIdAsync(id);
		if(originalEntity is not null)
		{
			_context.Set<T>().Update(entity);
			await SaveChangesAsync();
		}
	}

	private int GetPageSize()
	{
		int.TryParse(_configuration["CustomConfiguration:PageSize"], out int pageSize);
		return pageSize;
	}
	
}
