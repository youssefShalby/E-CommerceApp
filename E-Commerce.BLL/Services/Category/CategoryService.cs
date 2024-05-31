


namespace E_Commerce.BLL.Services;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepo _categoryRepo;
    public CategoryService(ICategoryRepo categoryRepo)
    {
		_categoryRepo = categoryRepo;
    }

    public async Task<CommonResponse> CreateAsync(CreateCategoryDto model)
	{
		Category newCategory = new Category
		{
			Id = Guid.NewGuid(),
			Name = model.Name,
		};

		try
		{
			await _categoryRepo.CreateAsync(newCategory);
			return new CommonResponse("Category Created..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when create category, reason: {ex.Message}", false);
		}
		
	}

	public async Task<CommonResponse> DeleteAsync(Guid id)
	{
		try
		{
			await _categoryRepo.DeleteAsync(id);
			return new CommonResponse("Category Deleted..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when delete category, reason: {ex.Message}", false);
		}
	}

	public async Task<IReadOnlyList<GetCategoryDto>> GetAllAsync(int page)
	{
		var categories = await _categoryRepo.GetAllAsync(page);
		return categories.Select(category => new GetCategoryDto
		{
			Name = category.Name,
			CreatedAt = category.CreatedAt

		}).ToList();
	}

	public async Task<IReadOnlyList<GetCategoryWithIncludesDto>> GetAllWithIncludesAsync(int page, params Expression<Func<Category, object>>[] includes)
	{
		try
		{
			var categories = await _categoryRepo.GetAllWithIncludesAsync(page, includes);
			return categories.Select(category => new GetCategoryWithIncludesDto
			{
				Name = category.Name,
				CreatedAt = category.CreatedAt,
				Products = category.Products.Select(product => ProductMapper.ToGetDto(product)).ToList()

			}).ToList();
		}
		catch (Exception ex)
		{
			return null!;
		}
	}

	public async Task<GetCategoryDto> GetByIdAsync(Guid id)
	{
		var category = await _categoryRepo.GetByIdAsync(id);
		if(category is null)
		{
			return null!;
		}
		return new GetCategoryDto
		{
			CreatedAt = category.CreatedAt,
			Name = category.Name
		};
	}

	public async Task<GetCategoryWithIncludesDto> GetByIdWithIncludesAsync(Guid id)
	{
		var category = await _categoryRepo.GetByIdWithIncludesAsync(id);
		if (category is null)
		{
			return null!;
		}
		return new GetCategoryWithIncludesDto
		{
			CreatedAt = category.CreatedAt,
			Name = category.Name,
			Products = category.Products.Select(product => ProductMapper.ToGetDto(product)).ToList()
		};
	}

	public async Task<CommonResponse> UpdateAsync(Guid id, UpdateCategoryDto model)
	{
		var category = await _categoryRepo.GetByIdWithIncludesAsync(id);
		if(category is null)
		{
			return new CommonResponse("cannot find the category..!!", false);
		}

		try
		{
			category.IsDeleted = model.IsDeleted;
			category.Name = model.Name;
			await _categoryRepo.UpdateAsync(category);
			return new CommonResponse("category updated..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when update category, reason: {ex.Message}", false);
		}
	}
}
