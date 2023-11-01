
namespace backend.Models;

public class Income: IValidInput
{
    [JsonPropertyName("assessed_income")]
    public int AssessedIncome {get; set;}
}
