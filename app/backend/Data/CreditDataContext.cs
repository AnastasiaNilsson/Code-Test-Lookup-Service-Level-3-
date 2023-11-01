
namespace backend.Data;

public class CreditDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=Database.sqlite");
        options.EnableSensitiveDataLogging();
    }

    public DbSet<CreditData> CreditDataSet { get; set; }
}
