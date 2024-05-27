
namespace E_Commerce.BLL.DTOs;

public class CommonResponse
{
    public string Message { get; set; } = string.Empty;
    public bool IsSuccessed { get; set; }
    public object AdditionalInfo { get; set; }
    public IEnumerable<string> Errors { get; set; }
    public CommonResponse(string msg, bool isSuccessed, List<string> errors = null!, object additionalInfo = null!)
    {
        Errors = errors;
        AdditionalInfo = additionalInfo;
        Message = msg;
        IsSuccessed = isSuccessed;
    }
}
