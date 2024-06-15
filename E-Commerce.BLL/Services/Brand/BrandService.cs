



namespace E_Commerce.BLL.Services;

public class BrandService : IBrandService
{
	private readonly IUnitOfWork _unitOfWork;
    public BrandService(IUnitOfWork unitOfWork)
    {
		_unitOfWork = unitOfWork;
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
			await _unitOfWork.BrandRepo.CreateAsync(newBrand);
			return new CommonResponse("Brand Created..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when update brand, reason: {ex.Message}", false);
		}
	}

	public async Task<CommonResponse> DeleteAsync(Guid id)
	{
		var brandToDelete = await _unitOfWork.BrandRepo.GetByIdAsync(id);
		if(brandToDelete is null)
		{
			return new CommonResponse("cannot find the brand to delete..!!", false);
		}
		try
		{
			await _unitOfWork.BrandRepo.DeleteAsync(id);
			return new CommonResponse("brand deleted..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when delete brand, reason: {ex.Message}", false);
		}
	}

	public async Task<IReadOnlyList<GetBrandDto>> GetAllAsync(int page)
	{
		var brands = await _unitOfWork.BrandRepo.GetAllAsync(page);
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

	public async Task<IReadOnlyList<GetBrandDto>> GetAllWithFilterAsync(BrandQueryHandler queryHandler)
	{
		var brands = await _unitOfWork.BrandRepo.GetAllWithQueryAsync(queryHandler);
		if (brands is null)
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
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<IReadOnlyList<GetBrandWithIncludesDto>> GetAllWithIncludes(int page, params Expression<Func<Brand, object>>[] includes)
	{
		var brands = await _unitOfWork.BrandRepo.GetAllWithIncludesAsync(page, includes);
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
		var brand = await _unitOfWork.BrandRepo.GetByIdAsync(id);
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
		var brand = await _unitOfWork.BrandRepo.GetByIdWithIncludesAsync(id);
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
		var brand = await _unitOfWork.BrandRepo.GetByIdAsync(id);
		if(brand is null)
		{
			return new CommonResponse($"cannot find Brand..!!", false);
		}

		try
		{
			brand.Name = model.Name;
			brand.IsDeleted = model.IsDeleted;
			await _unitOfWork.BrandRepo.UpdateAsync(brand);
			return new CommonResponse("brand updated..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when update brand, reason: {ex.Message}", false);
		}

	}
}
