namespace backend.Services;

public class MockDbService : IDbService
{
    public List<CreditData> CreditDataList = new List<CreditData>()
    {
        new CreditData() 
        {
            SocialSecurityNumber = "19851223-3951",
            CreatedAtTime = DateTime.Now - TimeSpan.FromSeconds(500),
            CacheLimit = TimeSpan.FromSeconds(100)
        },
        new CreditData()
        {
            SocialSecurityNumber = "19871222-3950",
            CreatedAtTime = DateTime.Now - TimeSpan.FromSeconds(500),
            CacheLimit = TimeSpan.FromSeconds(1000)
        }
    };

    public CreditData? GetData(string ssn) 
    {
        return CreditDataList.FirstOrDefault(data => data.SocialSecurityNumber == ssn);
    }
    public void SaveData(CreditData creditData) {}
    public void DeleteData(CreditData creditData) {}
}
