
namespace backend.Models;

public class ApiServicePartialResponse
{
    public IValidInput Data {get; set;}
    public CacheControlHeaderValue CacheControl {get; set;}

    public ApiServicePartialResponse(IValidInput data, CacheControlHeaderValue cacheControl)
    {
        Data = data;
        CacheControl = cacheControl;
    }
}
