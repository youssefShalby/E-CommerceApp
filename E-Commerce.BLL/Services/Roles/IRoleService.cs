
namespace E_Commerce.BLL.Services;

public interface IRoleService
{
	Task<CommonResponse> CreateRole(AddRoleDto model);
	Task<CommonResponse> DeleteRole(string roleId);
}
