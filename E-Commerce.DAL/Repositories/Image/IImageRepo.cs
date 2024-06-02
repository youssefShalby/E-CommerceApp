
namespace E_Commerce.DAL.Repositories;

public interface IImageRepo : IGenericRepo<Image>
{
	Task DeleteImagesOfProduct(Guid productId);
}
