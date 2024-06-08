

namespace E_Commerce.DAL.Repositories;

public class OrderRepo : GenericRepo<Order>, IOrderRepo
{
	private readonly AppDbContext _context;
	private readonly IConfiguration _configuration;
	public OrderRepo(AppDbContext context, IConfiguration configuration) : base(context, configuration)
    {
		_context = context;
		_configuration = configuration;
	}

	public async Task<Order> GetByIdWithIncludesAsync(Guid id)
	{
		return await _context.Set<Order>()
			.Include(O => O.OrderItems)
			.Include(O => O.DeliveryMethod)
			.FirstOrDefaultAsync(O => O.Id == id) ?? null!;
	}

	public async Task<Order> GetByPaymentIntentWithIncludesAsync(string paymentIntentId)
	{
		return await _context.Set<Order>()
			.Include(O => O.OrderItems)
			.Include(O => O.DeliveryMethod)
			.FirstOrDefaultAsync(O => O.PaymentIntentId == paymentIntentId) ?? null!;
	}
}
