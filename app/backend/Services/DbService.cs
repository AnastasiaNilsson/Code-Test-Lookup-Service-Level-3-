
namespace backend.Services;

public class DbService: IDbService
{
    private CreditDataContext _context;
    public DbService(CreditDataContext context) => _context = context;


    public void DeleteData(CreditData creditData)
    {
        _context.CreditDataSet.Remove(creditData);
        _context.SaveChanges();
    }

    public CreditData? GetData(string ssn) => _context.CreditDataSet.Find(ssn);

    public void SaveData(CreditData creditData)
    {
        var existingData = _context.CreditDataSet.Find(creditData.SocialSecurityNumber);
        if (existingData != null)
        {
            DeleteData(existingData);
        }
        _context.CreditDataSet.Add(creditData);
        _context.SaveChanges();
    }
}
