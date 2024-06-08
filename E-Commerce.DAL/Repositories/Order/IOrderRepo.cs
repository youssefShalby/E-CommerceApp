

namespace E_Commerce.DAL.Repositories;

public interface IOrderRepo : IGenericRepo<Order>
{
	Task<Order> GetByIdWithIncludesAsync(Guid id);
	Task<Order> GetByPaymentIntentWithIncludesAsync(string paymentIntentId);
	//> impelement another methods here to serve the app
}
