



namespace E_Commerce.DAL.Repositories;

public class ProductRepo : GenericRepo<Product>, IProductRepo
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    public ProductRepo(AppDbContext context, IConfiguration configuration) : base(context, configuration)
    {
        _context = context;
        _configuration = configuration;
    }

	public async Task<Product> GetByIdWithIncludesAsync(Guid id)
	{
        return await _context.Set<Product>()
            .Include(P => P.Category)
            .Include(P => P.Brand)
            .FirstOrDefaultAsync(P => P.Id == id) ?? new();
	}
}
