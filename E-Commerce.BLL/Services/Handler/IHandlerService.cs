	
namespace E_Commerce.BLL.Services;

public interface IHandlerService
{
	List<string> GetErrorsOfIdentityResult(IEnumerable<IdentityError> errors);
	Task<CommonResponse> RegisterHandlerAsync(RegisterUserDto model, string mainRole, params string[] otherRoles);
}
