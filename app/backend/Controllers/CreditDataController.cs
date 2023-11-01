
namespace backend.Controllers;

[ApiController]
[Route("credit-data")]
public class CreditDataController : Controller
{
    
    private DbService _dbService;
    private ApiService _apiService = new ();
    public CreditDataController(CreditDataContext context) => _dbService = new DbService(context);

    [HttpGet("{ssn}")]
    public async Task<ActionResult<CreditData>> Get(string ssn)
    {
        try
        {
            var cacheController = new CacheController(_dbService).AddConstraints(Request.Headers.CacheControl);
            if (cacheController.HasValidData(ssn, out var creditData)) return creditData;

            var response = await _apiService.GetCreditData(ssn);
            cacheController.AddConstraints(response.CacheControl);

            if (cacheController.OkToCache())
            {
                _dbService.SaveData(response.CreditData);
            }

            return response.CreditData;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound();
        }
    } 
}
