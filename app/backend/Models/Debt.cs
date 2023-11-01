
namespace backend.Models;

public class Debt: IValidInput
{
    [JsonPropertyName("balance_of_debt")]
    public int DebtBalance {get; set;}

    [JsonPropertyName("complaints")]
    public bool Complaints {get; set;}
}
