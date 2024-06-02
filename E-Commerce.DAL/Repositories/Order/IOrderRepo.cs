

namespace E_Commerce.DAL.Repositories;

public interface IOrderRepo : IGenericRepo<Order>
{
	Task<Order> GetByIdWithIncludesAsync(Guid id);
	//> impelement another methods here to serve the app
}
