
namespace backend.Models;

public class Details: IValidInput
{
    [JsonPropertyName("first_name")]
    public string FirstName {get; set;}

    [JsonPropertyName("last_name")]
    public string LastName {get; set;}

    [JsonPropertyName("address")]
    public string Address {get; set;}
}
