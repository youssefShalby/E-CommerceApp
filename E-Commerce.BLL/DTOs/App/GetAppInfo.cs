

namespace E_Commerce.BLL.DTOs;

public class GetAppInfo
{
    public int ProductsCount { get; set; }
    public int OrdersCount { get; set; }
    public int AllCategoriesCount { get; set; }
    public int DeletedCategoreisCount { get; set; }
    public int ExistCategoreisCount { get; set; }
    public int AllBrandCount { get; set; }
    public int DeletedBrandCount { get; set; }
    public int ExistBrandCount { get; set; }
    public int DeliveryMethodsCount { get; set; }
    public int UsersCount { get; set; }
    public int AdminsCount { get; set; }
}
