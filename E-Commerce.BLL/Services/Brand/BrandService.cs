﻿


namespace E_Commerce.BLL.Services;

public class BrandService : IBrandService
{
	private readonly IBrandRepo _brandRepo;
    public BrandService(IBrandRepo brandRepo)
    {
		_brandRepo = brandRepo;
    }

    public async Task<CommonResponse> CreateAsync(CreateBrandDto model)
	{
		Brand newBrand = new Brand
		{
			Name = model.Name,
			CreatedAt = model.CreatedAt
		};

		try
		{
			await _brandRepo.CreateAsync(newBrand);
			return new CommonResponse("Brand Created..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when update brand, reason: {ex.Message}", false);
		}
	}

	public async Task<CommonResponse> DeleteAsync(Guid id)
	{
		var brandToDelete = await _brandRepo.GetByIdAsync(id);
		if(brandToDelete is null)
		{
			return new CommonResponse("cannot find the brand to delete..!!", false);
		}
		try
		{
			await _brandRepo.DeleteAsync(id);
			return new CommonResponse("brand deleted..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when delete brand, reason: {ex.Message}", false);
		}
	}

	public async Task<IReadOnlyList<GetBrandDto>> GetAllAsync(int page)
	{
		var brands = await _brandRepo.GetAllAsync(page);
		if(brands is null)
		{
			return null!;
		}

		try
		{
			return brands.Select(brand => new GetBrandDto
			{
				CreatedAt = brand.CreatedAt,
				Name = brand.Name

			}).ToList();
		}
		catch(Exception)
		{
			return null!;
		}
	}

	public async Task<IReadOnlyList<GetBrandWithIncludesDto>> GetAllWithIncludes(int page, params Expression<Func<Brand, object>>[] includes)
	{
		var brands = await _brandRepo.GetAllWithIncludesAsync(page, includes);
		if (brands is null)
		{
			return null!;
		}

		try
		{
			return brands.Select(brand => new GetBrandWithIncludesDto
			{
				CreatedAt = brand.CreatedAt,
				Name = brand.Name,
				Products = brand.Products.Select(product => ProductMapper.ToGetDto(product)).ToList()

			}).ToList();
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<GetBrandDto> GetByIdAsync(Guid id)
	{
		var brand = await _brandRepo.GetByIdAsync(id);
		if(brand is null)
		{
			return null!;
		}

		try
		{
			return new GetBrandDto
			{
				CreatedAt = brand.CreatedAt,
				Name = brand.Name
			};
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<GetBrandWithIncludesDto> GetByIdWithIncludes(Guid id)
	{
		var brand = await _brandRepo.GetByIdWithIncludesAsync(id);
		if (brand is null)
		{
			return null!;
		}

		try
		{
			return new GetBrandWithIncludesDto
			{
				CreatedAt = brand.CreatedAt,
				Name = brand.Name,
				Products = brand.Products.Select(product => ProductMapper.ToGetDto(product)).ToList()
			};
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<CommonResponse> UpdateAsync(Guid id, UpdateBrandDto model)
	{
		var brand = await _brandRepo.GetByIdAsync(id);
		if(brand is null)
		{
			return new CommonResponse($"cannot find Brand..!!", false);
		}

		try
		{
			brand.Name = model.Name;
			brand.IsDeleted = model.IsDeleted;
			await _brandRepo.UpdateAsync(brand);
			return new CommonResponse("brand updated..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when update brand, reason: {ex.Message}", false);
		}

	}
}