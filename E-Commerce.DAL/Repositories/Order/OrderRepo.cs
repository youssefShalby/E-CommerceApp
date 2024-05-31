
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
}
