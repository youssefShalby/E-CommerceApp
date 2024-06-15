


namespace E_Commerce.DAL.Repositories;

public class OrderRepo : GenericRepo<Order>, IOrderRepo
{
	private readonly AppDbContext _context;
	private readonly IConfiguration _configuration;
	private readonly IConfigHelper _helper;
	public OrderRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper) : base(context, configuration, helper)
    {
		_context = context;
		_configuration = configuration;
		_helper = helper;
	}

	public async Task<IEnumerable<Order>> GetAllCreatedOrdersByUserAsync(string userEmail, int pageNumber)
	{
		return await _context.Orders.AsNoTracking()
			.Include(O => O.OrderItems)
			.Include(O => O.DeliveryMethod)
			.Where(P => P.BuyerEmail == userEmail)
			.Skip((pageNumber - 1) * _helper.GetPageSize())
			.Take(_helper.GetPageSize())
			.ToListAsync();
	}

	public async Task<IEnumerable<Order>> GetAllWithQueryAsync(OrderQueryHandler queryHandler)
	{
		var orders = _context.Orders
			.AsNoTracking()
			.Include(O => O.DeliveryMethod)
			.Include(O => O.OrderItems)
			.AsQueryable();

		if (!string.IsNullOrEmpty(queryHandler.OrderBy))
		{
			if (queryHandler.OrderBy.Equals("price"))
			{
				orders = queryHandler.IsDescending ? orders.OrderByDescending(O => O.TotalPrice) : orders.OrderBy(O => O.TotalPrice);
			}
			if (queryHandler.OrderBy.Equals("date"))
			{
				orders = queryHandler.IsDescending ? orders.OrderByDescending(O => O.OrderDate) : orders.OrderBy(O => O.OrderDate);
			}
		}

		orders = orders.Skip((queryHandler.PageNumber - 1) * queryHandler.PageSize).Take(queryHandler.PageSize);
		return await orders.ToListAsync();
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
