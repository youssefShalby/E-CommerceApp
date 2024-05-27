using Microsoft.Extensions.ObjectPool;

namespace E_Commerce.API.Errors;

public class ApiValidationErrorResponse : ApiResponse
{
    //> pass the error code for the parent, and message is optional
    public ApiValidationErrorResponse() : base(400)
    {
        Errors = new string[] { };
    }

    public IEnumerable<string> Errors { get; set; }
}
