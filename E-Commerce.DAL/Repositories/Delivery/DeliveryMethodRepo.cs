


namespace E_Commerce.DAL.Repositories;

public class DeliveryMethodRepo : GenericRepo<DeliveryMethod>, IDeliveryMethodRepo
{
	private readonly AppDbContext _context;
	public DeliveryMethodRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper) : base(context, configuration, helper)
	{
		_context = context;
	}

	public async Task<DeliveryMethod> GetByIdWithIncludes(Guid id)
	{
		return await _context.Set<DeliveryMethod>()
			.Include(DM => DM.Orders)
			.FirstOrDefaultAsync(DM => DM.Id == id) ?? null!;
	}

	public int GetCount()
	{
		return _context.DeliveryMethods is null ? 0 : _context.DeliveryMethods.Count();
	}
}
