



namespace E_Commerce.DAL.Repositories;

public interface IOrderRepo : IGenericRepo<Order>
{
	Task<Order> GetByIdWithIncludesAsync(Guid id);
	Task<Order> GetByPaymentIntentWithIncludesAsync(string paymentIntentId);
	Task<IEnumerable<Order>> GetAllWithQueryAsync(OrderQueryHandler queryHandler);
	Task<IEnumerable<Order>> GetAllCreatedOrdersByUserAsync(string userEmail, int pageNumber);
	int GetCount();

	//> impelement another methods here to serve the app
}
