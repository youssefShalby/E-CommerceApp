
namespace E_Commerce.BLL.IdentityHelper;

public class Handler
{
	public static List<string> GetErrors(IEnumerable<IdentityError> errors)
	{
		List<string> result = new List<string>(5);
		foreach (var error in errors)
		{
			result.Add(error.ToString() ?? "NA");
		}
		return result;
	}

	public static string GetFirstFiveChardsFromId(string id)
	{
		return id.Substring(0, 5);
	}
}
