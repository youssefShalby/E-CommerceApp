

namespace E_Commerce.DAL.Repositories;

public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
{
	private readonly AppDbContext _context;
	private readonly IConfiguration _configuration;
	public CategoryRepo(AppDbContext context, IConfiguration configuration) : base(context, configuration)
	{
		_context = context;
		_configuration = configuration;
	}

	public async Task<Category> GetByIdWithIncludesAsync(Guid id)
	{
		return await _context.Set<Category>()
			.Include(C => C.Products)
			.FirstOrDefaultAsync(C => C.Id == id) ?? null!;
	}
}
