

namespace E_Commerce.DAL.Repositories;

public interface IDeliveryMethodRepo : IGenericRepo<DeliveryMethod>
{
	Task<DeliveryMethod> GetByIdWithIncludes(Guid id);
	int GetCount();
}
