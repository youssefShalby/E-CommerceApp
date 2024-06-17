
namespace E_Commerce.BLL.Services;

public interface IDeliveryMethodService
{
	Task<GetDeliveryDto> GetByIdAsync(Guid id);
	Task<GetDeliveryWithIncludes> GetByIdWithIncludesAsync(Guid id);
	Task<IReadOnlyList<GetDeliveryDto>> GetAllAsync(int page);
	Task<IReadOnlyList<GetDeliveryWithIncludes>> GetAllWithIncludesAsync(int page, params Expression<Func<DeliveryMethod, object>>[] includes);
	Task<CommonResponse> CreateAsync(CreateDeliveryMethodDto model);
	Task<CommonResponse> UpdateAsync(Guid id, UpdateDeliverMethodDto model);
	Task<CommonResponse> DeleteAsync(Guid id);
	int GetCount();
}
