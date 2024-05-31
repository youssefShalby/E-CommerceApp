
namespace E_Commerce.DAL.Repositories;

public interface IImageRepo
{
	Task DeleteImagesOfProduct(Guid productId);
}
