
namespace E_Commerce.BLL.Services;

public class RoleService : IRoleService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IHandlerService _handlerService;
	public RoleService(IUnitOfWork unitOfWork, IHandlerService handlerService)
	{
		_unitOfWork = unitOfWork;
		_handlerService = handlerService;
	}

	public async Task<CommonResponse> CreateRole(AddRoleDto model)
	{
		if (model is null)
		{
			return new CommonResponse("some or all fields are empty..", false);
		}
		IdentityRole newRole = new()
		{
			Name = model.Name,
		};
		IdentityResult result = await _unitOfWork.RoleManager.CreateAsync(newRole);
		if (!result.Succeeded)
		{
			var errors = _handlerService.GetErrorsOfIdentityResult(result.Errors);
			return new CommonResponse("create role fail", false, errors);
		}

		return new CommonResponse("Role Created", true);
	}

	public async Task<CommonResponse> DeleteRole(string roleName)
	{
		var role = await _unitOfWork.RoleManager.FindByNameAsync(roleName);
		if(role is null)
		{
			return new CommonResponse("role not found..!!", false);
		}

		var result = await _unitOfWork.RoleManager.DeleteAsync(role);
		if(!result.Succeeded)
		{
			var errors = _handlerService.GetErrorsOfIdentityResult(result.Errors);
			return new CommonResponse("Cannot delete Role..!!", false, errors);
		}
		return new CommonResponse("Role Deleted..", true);
	}

}
