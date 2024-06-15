


namespace E_Commerce.DAL.Repositories;

public class BrandRepo : GenericRepo<Brand>, IBrandRepo
{
	private readonly AppDbContext _context;
	private readonly IConfiguration _configuration;
	public BrandRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper) : base(context, configuration, helper)
	{
		_context = context;
		_configuration = configuration;
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
			brands = brands.Where(brand => brand.Name.Contains(queryHandler.Name));
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
}
