

namespace E_Commerce.DAL.Repositories;

public class BrandRepo : GenericRepo<Brand>, IBrandRepo
{
	private readonly AppDbContext _context;
	private readonly IConfiguration _configuration;
	public BrandRepo(AppDbContext context, IConfiguration configuration) : base(context, configuration)
	{
		_context = context;
		_configuration = configuration;
	}

	public async Task<Brand> GetByIdWithIncludesAsync(Guid id)
	{
		return await _context.Set<Brand>()
			.Include(C => C.Products)
			.FirstOrDefaultAsync(C => C.Id == id) ?? null!;
	}
}
