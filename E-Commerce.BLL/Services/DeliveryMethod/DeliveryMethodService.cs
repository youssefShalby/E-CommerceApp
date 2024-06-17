

namespace E_Commerce.BLL.Services;

public class DeliveryMethodService : IDeliveryMethodService
{
	private readonly IUnitOfWork _unitOfWork;
	public DeliveryMethodService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<CommonResponse> CreateAsync(CreateDeliveryMethodDto model)
	{
		DeliveryMethod newDeliveryMethod = new DeliveryMethod
		{
			DeliveryTime = model.DeliveryTime,
			Description = model.Description,
			Id = Guid.NewGuid(),
			Price = model.Price,
			ShortName = model.ShortName
		};

		try
		{
			await _unitOfWork.DeliveryMethodRepo.CreateAsync(newDeliveryMethod);
			await _unitOfWork.DeliveryMethodRepo.SaveChangesAsync();
			return new CommonResponse("delivery method created..!!", true);
		}
		catch (Exception ex)
		{
			return new CommonResponse($"cannot create deliver method right now, reason: {ex.Message}", false);
		}

	}

	public async Task<CommonResponse> DeleteAsync(Guid id)
	{
		var deliverToDelete = await _unitOfWork.DeliveryMethodRepo.GetByIdAsync(id);
		if(deliverToDelete is null)
		{
			return new CommonResponse("cannot find delivery method..!!", false);
		}

		try
		{
			await _unitOfWork.DeliveryMethodRepo.DeleteAsync(id);
			await _unitOfWork.DeliveryMethodRepo.SaveChangesAsync();
			return new CommonResponse("deliver method deleted", true);

		}
		catch (Exception ex)
		{
			return new CommonResponse($"error when delete delivery method, reson: {ex.Message}", false);
		}
	}

	public async Task<IReadOnlyList<GetDeliveryDto>> GetAllAsync(int page)
	{
		var deliveryMethods = await _unitOfWork.DeliveryMethodRepo.GetAllAsync(page);
		if(deliveryMethods is null)
		{
			return null!;
		}
		try
		{
			return deliveryMethods.Select(delivery => new GetDeliveryDto
			{
				DeliveryTime = delivery.DeliveryTime,
				Description = delivery.Description,
				Price = delivery.Price,
				ShortName = delivery.ShortName

			}).ToList();
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<IReadOnlyList<GetDeliveryWithIncludes>> GetAllWithIncludesAsync(int page, params Expression<Func<DeliveryMethod, object>>[] includes)
	{
		var deliveryMethods = await _unitOfWork.DeliveryMethodRepo.GetAllWithIncludesAsync(page, includes);
		if (deliveryMethods is null)
		{
			return null!;
		}
		try
		{
			return deliveryMethods.Select(delivery => new GetDeliveryWithIncludes
			{
				DeliveryTime = delivery.DeliveryTime,
				Description = delivery.Description,
				Price = delivery.Price,
				ShortName = delivery.ShortName,

				Orders = delivery.Orders!.Select(order => new GetOrderToDeliverDto
				{
					BuyerEmail = order.BuyerEmail,
					OrderDate  = order.OrderDate

				}).ToList()

			}).ToList();
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<GetDeliveryDto> GetByIdAsync(Guid id)
	{
		var deliveryMethod = await _unitOfWork.DeliveryMethodRepo.GetByIdAsync(id);
		if (deliveryMethod is null)
		{
			return null!;
		}
		try
		{
			return new GetDeliveryDto
			{
				DeliveryTime = deliveryMethod.DeliveryTime,
				Description = deliveryMethod.Description,
				Price = deliveryMethod.Price,
				ShortName = deliveryMethod.ShortName
			};
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public async Task<GetDeliveryWithIncludes> GetByIdWithIncludesAsync(Guid id)
	{
		var deliveryMethod = await _unitOfWork.DeliveryMethodRepo.GetByIdWithIncludes(id);
		if (deliveryMethod is null)
		{
			return null!;
		}
		try
		{
			return new GetDeliveryWithIncludes
			{
				DeliveryTime = deliveryMethod.DeliveryTime,
				Description = deliveryMethod.Description,
				Price = deliveryMethod.Price,
				ShortName = deliveryMethod.ShortName,
				Orders = deliveryMethod.Orders!.Select(order => new GetOrderToDeliverDto
				{
					BuyerEmail = order.BuyerEmail,
					OrderDate = order.OrderDate

				}).ToList()
			};
		}
		catch (Exception)
		{
			return null!;
		}
	}

	public int GetCount()
	{
		return _unitOfWork.DeliveryMethodRepo.GetCount();
	}

	public async Task<CommonResponse> UpdateAsync(Guid id, UpdateDeliverMethodDto model)
	{
		var deliveryMethod = await _unitOfWork.DeliveryMethodRepo.GetByIdWithIncludes(id);
		if (deliveryMethod is null)
		{
			return new CommonResponse("cannot find the delivery method..!!", false) ;
		}

		try
		{
			deliveryMethod.DeliveryTime = model.DeliveryTime;
			deliveryMethod.Description = model.Description;
			deliveryMethod.Price = model.Price;
			deliveryMethod.ShortName = model.ShortName;
			_unitOfWork.DeliveryMethodRepo.Update(deliveryMethod);
			await _unitOfWork.DeliveryMethodRepo.SaveChangesAsync();
			return new CommonResponse("delivery method updated..!!", true);
		}
		catch(Exception ex)
		{
			return new CommonResponse($"error when update delivery method, reason: {ex.Message}", false);
		}
	}
}
