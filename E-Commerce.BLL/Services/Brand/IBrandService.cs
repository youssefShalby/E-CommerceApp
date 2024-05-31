

namespace E_Commerce.BLL.Services;

public interface IBrandService
{
	Task<GetBrandDto> GetByIdAsync(Guid id);
	Task<GetBrandWithIncludesDto> GetByIdWithIncludes(Guid id);
	Task<IReadOnlyList<GetBrandDto>> GetAllAsync(int page);
	Task<IReadOnlyList<GetBrandWithIncludesDto>> GetAllWithIncludes(int page, params Expression<Func<Brand, object>>[] includes);
	Task<CommonResponse> CreateAsync(CreateBrandDto model);
	Task<CommonResponse> UpdateAsync(Guid id, UpdateBrandDto model);
	Task<CommonResponse> DeleteAsync(Guid id);
}
