﻿



namespace E_Commerce.BLL.Services;

public class CategoryService : ICategoryService
{
	private readonly IUnitOfWork _unitOfWork;
	public CategoryService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
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
			await _unitOfWork.CategoryRepo.CreateAsync(newCategory);
			await _unitOfWork.CategoryRepo.SaveChangesAsync();
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
			await _unitOfWork.CategoryRepo.DeleteAsync(id);
			await _unitOfWork.CategoryRepo.SaveChangesAsync();
			return new CommonResponse("Category Deleted..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when delete category, reason: {ex.Message}", false);
		}
	}

	public async Task<IReadOnlyList<GetCategoryDto>> GetAllAsync(int page)
	{
		var categories = await _unitOfWork.CategoryRepo.GetAllAsync(page);
		return categories.Select(category => new GetCategoryDto
		{
			Name = category.Name,
			CreatedAt = category.CreatedAt

		}).ToList();
	}

	public async Task<IReadOnlyList<GetCategoryDto>> GetAllWithFilterAsync(CategoryQueryHandler queryHandler)
	{
		var categories = await _unitOfWork.CategoryRepo.GetAllWithQueryAsync(queryHandler);
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
			var categories = await _unitOfWork.CategoryRepo.GetAllWithIncludesAsync(page, includes);
			return categories.Select(category => new GetCategoryWithIncludesDto
			{
				Name = category.Name,
				CreatedAt = category.CreatedAt,
				Products = category.Products.Select(product => ProductMapper.ToGetDto(product)).ToList()

			}).ToList();
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<IReadOnlyList<GetCategoryWithIncludesDto>> GetAllWithIncludesExceptDeletedAsync(int page)
	{
		try
		{
			var categories = await _unitOfWork.CategoryRepo.GetAllExceptDeletedAsync(page);
			return categories.Select(category => new GetCategoryWithIncludesDto
			{
				Name = category.Name,
				CreatedAt = category.CreatedAt,
				Products = category.Products.Select(product => ProductMapper.ToGetDto(product)).ToList()

			}).ToList();
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<GetCategoryDto> GetByIdAsync(Guid id)
	{
		var category = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
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
		var category = await _unitOfWork.CategoryRepo.GetByIdWithIncludesAsync(id);
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

	public int GetCount()
	{
		return _unitOfWork.CategoryRepo.GetCount();
	}

	public int GetDeletedCount()
	{
		return _unitOfWork.CategoryRepo.GetDeletedCount();
	}

	public async Task<CommonResponse> MarkeCategoryAsDeletedAsync(Guid id)
	{
		int result = await _unitOfWork.CategoryRepo.MarkCategoryAsDeletedAsync(id);
		if(result == -1)
		{
			return new CommonResponse("cannot find the category..!!", false);
		}
		return new CommonResponse("Category Deleted..!!", true);
	}

	public async Task<CommonResponse> UpdateAsync(Guid id, UpdateCategoryDto model)
	{
		var category = await _unitOfWork.CategoryRepo.GetByIdWithIncludesAsync(id);
		if(category is null)
		{
			return new CommonResponse("cannot find the category..!!", false);
		}

		try
		{
			category.IsDeleted = model.IsDeleted;
			category.Name = model.Name;
			_unitOfWork.CategoryRepo.Update(category);
			await _unitOfWork.CategoryRepo.SaveChangesAsync();
			return new CommonResponse("category updated..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when update category, reason: {ex.Message}", false);
		}
	}
}
