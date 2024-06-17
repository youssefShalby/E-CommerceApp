
namespace E_Commerce.BLL.IdentityHelper;

public class Handler
{
	public static string GetFirstFiveChardsFromId(string id)
	{
		return id.Substring(0, 5);
	}
}
