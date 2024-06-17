

namespace E_Commerce.DAL.Repositories;

public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
{
	private readonly AppDbContext _context;
	private readonly IConfigHelper _helper;
	public CategoryRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper) : base(context, configuration, helper)
	{
		_context = context;
		_helper = helper;
	}

	public async Task<IReadOnlyList<Category>> GetAllExceptDeletedAsync(int page)
	{
		return await _context.Set<Category>()
			.AsNoTracking()
			.Include(C => C.Products)
			.Where(category => category.IsDeleted == false)
			.Skip((page - 1) * _helper.GetPageSize()).Take(_helper.GetPageSize())
			.ToListAsync();
	}

	public async Task<IEnumerable<Category>> GetAllWithQueryAsync(CategoryQueryHandler queryHandler)
	{
		var categories = _context.Categories
			.AsNoTracking()
			.Include(C => C.Products)
			.AsQueryable();

		//> Search | filter
		if (!string.IsNullOrEmpty(queryHandler.Name))
		{
			categories = categories.Where(category => category.Name.Contains(queryHandler.Name) && category.IsDeleted == false);
		}

		//> Sort
		if (!string.IsNullOrEmpty(queryHandler.OrderBy))
		{
			if (queryHandler.OrderBy.Equals("name"))
			{
				categories = queryHandler.IsDescending ? categories.OrderByDescending(c => c.Name) : categories.OrderBy(c => c.Name);
			}
			if (queryHandler.OrderBy.Equals("date"))
			{
				categories = queryHandler.IsDescending ? categories.OrderByDescending(c => c.CreatedAt) : categories.OrderBy(c => c.CreatedAt);
			}
		}

		//> pagination
		categories = categories.Skip((queryHandler.PageNumber - 1) * queryHandler.PageSize).Take(queryHandler.PageSize);
		return await categories.ToListAsync();

	}

	public async Task<Category> GetByIdWithIncludesAsync(Guid id)
	{
		return await _context.Set<Category>()
			.Include(C => C.Products)
			.FirstOrDefaultAsync(C => C.Id == id) ?? null!;
	}

	public int GetCount()
	{
		return _context.Categories is null ? 0 : _context.Categories.Count();
	}

	public int GetDeletedCount()
	{
		return _context.Categories is null ? 0 : _context.Categories.Where(C => C.IsDeleted == true).Count();
	}

	public async Task<int> MarkCategoryAsDeletedAsync(Guid id)
	{
		var categoryToDelete = await _context.Set<Category>().FirstOrDefaultAsync(c => c.Id == id);
		if(categoryToDelete is null)
		{
			return -1;
		}

		categoryToDelete.IsDeleted = true;
		await _context.SaveChangesAsync();
		return 0;
	}
}
