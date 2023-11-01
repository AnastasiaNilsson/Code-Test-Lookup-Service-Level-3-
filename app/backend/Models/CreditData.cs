
namespace backend.Models;

public class CreditData
{
    [Key]
    [JsonIgnore]
    public string SocialSecurityNumber {get; set;}

    [JsonPropertyName("first_name")]
    public string FirstName {get; set;}

    [JsonPropertyName("last_name")]
    public string LastName {get; set;}

    [JsonPropertyName("address")]
    public string Address {get; set;}

    [JsonPropertyName("assessed_income")]
    public int AssessedIncome {get; set;}

    [JsonPropertyName("balance_of_debt")]
    public int DebtBalance {get; set;}

    [JsonPropertyName("complaints")]
    public bool Complaints {get; set;}

    [JsonIgnore]
    public DateTime CreatedAtTime {get; set;}

    [JsonIgnore]
    public TimeSpan CacheLimit {get; set;}

    public CreditData() {}
    public CreditData(string socialSecurityNumber, Details details, Income income, Debt debt, TimeSpan cacheLimit)
    {
        SocialSecurityNumber = socialSecurityNumber;
        FirstName = details.FirstName;
        LastName = details.LastName;
        Address = details.Address;
        AssessedIncome = income.AssessedIncome;
        DebtBalance = debt.DebtBalance;
        Complaints = debt.Complaints;
        CreatedAtTime = DateTime.Now;
        CacheLimit = cacheLimit;
    }

    public bool CacheHasExpired()
    {
        if (CacheLimit.TotalSeconds == 0) return false;
        return DateTime.Now > CreatedAtTime + CacheLimit;
    }

    public bool IsOlderThan(TimeSpan? maxAge) 
    {
        var currentAge = TimeSpan.FromSeconds((DateTime.Now - CreatedAtTime).TotalSeconds);
        return maxAge == null ? false : currentAge > maxAge;
    }
}
