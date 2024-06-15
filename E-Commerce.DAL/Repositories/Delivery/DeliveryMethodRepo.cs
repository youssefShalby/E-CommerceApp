


namespace E_Commerce.DAL.Repositories;

public class DeliveryMethodRepo : GenericRepo<DeliveryMethod>, IDeliveryMethodRepo
{
	private readonly AppDbContext _context;
	private readonly IConfiguration _configuration;
	public DeliveryMethodRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper) : base(context, configuration, helper)
	{
		_context = context;
		_configuration = configuration;
	}

	public async Task<DeliveryMethod> GetByIdWithIncludes(Guid id)
	{
		return await _context.Set<DeliveryMethod>()
			.Include(DM => DM.Orders)
			.FirstOrDefaultAsync(DM => DM.Id == id) ?? null!;
	}
}
