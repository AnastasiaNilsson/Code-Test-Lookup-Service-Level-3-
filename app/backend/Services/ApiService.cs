
namespace backend.Services;

public class ApiService
{
    private HttpClient _client = new ();
    private string _apiBaseUrl = "https://infra.devskills.app/api/credit-data";
    private Dictionary<Type,string> _apiPaths = new ()
    {
        {typeof(Details), "personal-details"},
        {typeof(Income), "assessed-income"},
        {typeof(Debt), "debt"}
    };

    private async Task<ApiServicePartialResponse> Get<T>(string ssn) where T : IValidInput
    {
        var path = _apiPaths[typeof(T)];

        var response = await _client.GetAsync($"{_apiBaseUrl}/{path}/{ssn}");
        if (response.StatusCode != HttpStatusCode.OK) throw new Exception("NotFound");

        var data = JsonSerializer.Deserialize<T>(await response.Content.ReadAsStreamAsync());
        return new ApiServicePartialResponse(data, response.Headers.CacheControl);
    }

    public async Task<ApiServiceFinalResponse> GetCreditData(string ssn)
    {
        var details = Get<Details>(ssn);
        var income = Get<Income>(ssn);
        var debt = Get<Debt>(ssn);

        await Task.WhenAll(details, income, debt);

        var detailsData = details.Result.Data as Details;
        var incomeData = income.Result.Data as Income;
        var debtData = debt.Result.Data as Debt;

        var cacheLimit = CacheController.GetLimit(details.Result.CacheControl);
        var creditData = new CreditData(ssn, detailsData, incomeData, debtData, cacheLimit);

        return new ApiServiceFinalResponse(creditData, details.Result.CacheControl);
    }
}
