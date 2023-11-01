
namespace backend.Models;

public class ApiServiceFinalResponse
{
    public CreditData CreditData { get; }
    public CacheControlHeaderValue CacheControl {get; set;}
    
    public ApiServiceFinalResponse(CreditData creditData, CacheControlHeaderValue controlValues)
    {
        CreditData = creditData;
        CacheControl = controlValues;
    }
}
