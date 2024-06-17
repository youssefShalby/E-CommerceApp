
namespace E_Commerce.BLL.Services;

public interface IOrderService
{
	Task<GetOrderDto> CreateOrderAsync(CreateOrderDto model);
	Task<IReadOnlyList<GetOrderDto>> GetAllAsync(int page, params Expression<Func<Order, object>>[] includes);
	Task<IReadOnlyList<GetOrderDto>> GetAllCreatedOrdersByUserAsync(GetCreatedOrdersByUser model);

	Task<IReadOnlyList<GetOrderDto>> GetAllWithFilterAsync(OrderQueryHandler queryHandler);
	Task<GetOrderDto> GetOrderAsync(Guid id);
	Task<CommonResponse> UpdateAsync(Guid id, UpdateOrderDto model);
	Task<CommonResponse> DeleteAsync(Guid id);
	int GetCount();
}
