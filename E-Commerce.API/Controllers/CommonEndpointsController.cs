﻿

namespace E_Commerce.API.Controllers;


public abstract class CommonEndpointsController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly IOrderService _orderService;
	private readonly IProductService _productService;
	private readonly ICategoryService _categoryService;
	private readonly IBrandService _brandService;
	private readonly IDeliveryMethodService _deliveryMethodService;

	public CommonEndpointsController(IUserService userService, IOrderService orderService, IProductService productService, ICategoryService categoryService, IBrandService brandService, IDeliveryMethodService deliveryMethodService)
	{
		_userService = userService;
		_orderService = orderService;
		_productService = productService;
		_categoryService = categoryService;
		_brandService = brandService;
		_deliveryMethodService = deliveryMethodService;
	}


	[HttpGet("AppInfo")]
	public ActionResult GetAppInfo()
	{
		GetAppInfo appInfo = new GetAppInfo
		{
			ProductsCount = _productService.GetCount(),
			OrdersCount = _orderService.GetCount(),
			UsersCount = _userService.GetUsersCount(),
			AdminsCount = _userService.GetAdminsCount(),
			DeliveryMethodsCount = _deliveryMethodService.GetCount(),
			AllCategoriesCount = _categoryService.GetCount(),
			DeletedCategoreisCount = _categoryService.GetDeletedCount(),
			ExistCategoreisCount = _categoryService.GetCount() - _categoryService.GetDeletedCount(),
			AllBrandCount = _brandService.GetCount(),
			DeletedBrandCount = _brandService.GetDeletedCount(),
			ExistBrandCount = _brandService.GetCount() - _brandService.GetDeletedCount(),
		};

		return Ok(appInfo);
	}

}
