﻿


namespace E_Commerce.DAL.Repositories;

public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
{
	private readonly AppDbContext _context;
	private readonly IConfiguration _configuration;
	public CategoryRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper) : base(context, configuration, helper)
	{
		_context = context;
		_configuration = configuration;
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
			categories = categories.Where(category => category.Name.Contains(queryHandler.Name));
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
}
