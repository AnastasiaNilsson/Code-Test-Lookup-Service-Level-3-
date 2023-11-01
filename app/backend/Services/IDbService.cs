
namespace backend.Services;

public interface IDbService
{
    public void SaveData(CreditData creditData);
    public void DeleteData(CreditData creditData);
    public CreditData? GetData(string ssn);
}
