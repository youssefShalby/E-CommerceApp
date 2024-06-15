

namespace E_Commerce.BLL.Services;

public interface ICategoryService
{
	Task<GetCategoryDto> GetByIdAsync(Guid id);
	Task<GetCategoryWithIncludesDto> GetByIdWithIncludesAsync(Guid id);
	Task<IReadOnlyList<GetCategoryDto>> GetAllAsync(int page);
	Task<IReadOnlyList<GetCategoryDto>> GetAllWithFilterAsync(CategoryQueryHandler queryHandler);
	Task<IReadOnlyList<GetCategoryWithIncludesDto>> GetAllWithIncludesAsync(int page, params Expression<Func<Category, object>>[] includes);
	Task<CommonResponse> CreateAsync(CreateCategoryDto model);
	Task<CommonResponse> UpdateAsync(Guid id, UpdateCategoryDto model);
	Task<CommonResponse> DeleteAsync(Guid id);
}
