


namespace E_Commerce.DAL.Repositories;

public class BrandRepo : GenericRepo<Brand>, IBrandRepo
{
	private readonly AppDbContext _context;
	private readonly IConfigHelper _helper;
	public BrandRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper) : base(context, configuration, helper)
	{
		_context = context;
		_helper = helper;
	}

	public async Task<IReadOnlyList<Brand>> GetAllExceptDeletedAsync(int page)
	{
		return await _context.Set<Brand>()
			.AsNoTracking()
			.Include(C => C.Products)
			.Where(category => category.IsDeleted == false)
			.Skip((page - 1) * _helper.GetPageSize()).Take(_helper.GetPageSize())
			.ToListAsync();
	}

	public async Task<IEnumerable<Brand>> GetAllWithQueryAsync(BrandQueryHandler queryHandler)
	{
		var brands = _context.Brands
			.AsNoTracking()
			.Include(C => C.Products)
			.AsQueryable();

		//> Search | filter
		if (!string.IsNullOrEmpty(queryHandler.Name))
		{
			brands = brands.Where(brand => brand.Name.Contains(queryHandler.Name) && brand.IsDeleted == false);
		}

		//> Sort
		if (!string.IsNullOrEmpty(queryHandler.OrderBy))
		{
			if (queryHandler.OrderBy.Equals("name"))
			{
				brands = queryHandler.IsDescending ? brands.OrderByDescending(b => b.Name) : brands.OrderBy(b => b.Name);
			}
			if (queryHandler.OrderBy.Equals("date"))
			{
				brands = queryHandler.IsDescending ? brands.OrderByDescending(b => b.CreatedAt) : brands.OrderBy(b => b.CreatedAt);
			}
		}

		//> pagination
		brands = brands.Skip((queryHandler.PageNumber - 1) * queryHandler.PageSize).Take(queryHandler.PageSize);
		return await brands.ToListAsync();
	}

	public async Task<Brand> GetByIdWithIncludesAsync(Guid id)
	{
		return await _context.Set<Brand>()
			.Include(C => C.Products)
			.FirstOrDefaultAsync(C => C.Id == id) ?? null!;
	}

	public int GetCount()
	{
		return _context.Brands is null ? 0 : _context.Brands.Count();
	}

	public int GetDeletedCount()
	{
		return _context.Brands is null ? 0 : _context.Brands.Where(B => B.IsDeleted == true).Count();
	}

	public async Task<int> MarkBrandAsDeletedAsync(Guid id)
	{
		var brandToDelete = await _context.Set<Brand>().FirstOrDefaultAsync(c => c.Id == id);
		if (brandToDelete is null)
		{
			return -1;
		}

		brandToDelete.IsDeleted = true;
		await _context.SaveChangesAsync();
		return 0;
	}
}
