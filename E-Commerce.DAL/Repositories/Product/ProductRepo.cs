

namespace E_Commerce.DAL.Repositories;

public class ProductRepo : GenericRepo<Product>, IProductRepo
{
    private readonly AppDbContext _context;
    private readonly IConfigHelper _helper;
    public ProductRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper) : base(context, configuration, helper)
    {
        _context = context;
        _helper = helper;
    }

	public async Task<IEnumerable<Product>> GetAllCreatedProductsByUserAsync(string userId, int pageNumber)
	{
        return await _context.Products.AsNoTracking()
            .Include(P => P.Brand)
            .Include(P => P.Category)
            .Where(P => P.UserId == userId)
            .Skip((pageNumber - 1) * _helper.GetPageSize())
            .Take(_helper.GetPageSize())
            .ToListAsync();
	}

	public async Task<IEnumerable<Product>> GetAllWithQueryAsync(ProductQueryHandler handler)
	{
		var products = _context.Products
            .AsNoTracking()
            .Include(P => P.Brand)
            .Include(P => P.Category)
            .AsQueryable();


        // Search
        if (!string.IsNullOrEmpty(handler.Name))
        {
            products = products.Where(P => P.Name.Contains(handler.Name));
        }
        if (!string.IsNullOrEmpty(handler.BrandName))
        {
            products = products.Where(P => P.Brand!.Name.Contains(handler.BrandName));
        }
        if (!string.IsNullOrEmpty(handler.CategoryName))
        {
            products = products.Where(P => P.Category!.Name.Contains(handler.CategoryName));
        }


        //> Sort
        if (!string.IsNullOrEmpty(handler.OrderBy))
        {
            if (handler.OrderBy.Equals("price"))
            {
                products = handler.IsDescending ? products.OrderByDescending(P => P.OfferPrice) : products.OrderBy(P => P.OfferPrice);
            }
            
            if (handler.OrderBy.Equals("date"))
            {
                products = handler.IsDescending ? products.OrderByDescending(P => P.CreatedAt) : products.OrderBy(P => P.CreatedAt);
            }
        }

        //> pagination
        products = products.Skip((handler.PageNumber - 1) * handler.PageSize).Take(handler.PageSize);
        return await products.ToListAsync();
	}

	public async Task<Product> GetByIdWithIncludesAsync(Guid id)
	{
        return await _context.Set<Product>()
            .Include(P => P.Category)
            .Include(P => P.Brand)
            .Include(P => P.Images)
            .FirstOrDefaultAsync(P => P.Id == id) ?? null!;
	}

	public int GetCount()
	{
		return _context.Products is null ? 0 : _context.Products.Count();
	}
}
