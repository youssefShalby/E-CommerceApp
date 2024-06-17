

namespace E_Commerce.DAL.Repositories;

public class ImageRepo : GenericRepo<Image>, IImageRepo
{
	private readonly AppDbContext _context;
    public ImageRepo(AppDbContext context, IConfiguration configuration, IConfigHelper helper) : base(context, configuration, helper)
    {
        _context = context;
    }

    public async Task DeleteImagesOfProduct(Guid productId)
	{
		var images = _context.ProductImages.Where(I => I.ProductId == productId);
		_context.ProductImages.RemoveRange(images);
		await _context.SaveChangesAsync();
	}
}
