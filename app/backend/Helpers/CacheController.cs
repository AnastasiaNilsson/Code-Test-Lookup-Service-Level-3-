
namespace backend.Helpers;

public class CacheController
{
    private IDbService _dbService;
    private TimeSpan? _maxAge = null;
    private bool _noStore  = false;

    public TimeSpan? MaxAge
    {
        get => _maxAge;
        set
        {
            if (_maxAge is null || (@value is not null && @value < _maxAge))
            {
                _maxAge = @value;
            }
        }
    }
    public bool NoStore
    {
        get => _noStore;
        set
        {
            if (_noStore == false) _noStore = @value;
        }
    }

    public CacheController(IDbService dbService) => _dbService = dbService;

    public CacheController AddConstraints(StringValues controlValues)
    {
        foreach (string value in controlValues)
        {
            if (value.Contains("no-store"))
            {
                NoStore = true;
            }

            if (value.Contains("max-age"))
            {
                var stringNumber = value.Substring(value.IndexOf("max-age") + 8);
                var success = Int32.TryParse(stringNumber, out var maxAgeInSeconds);
                MaxAge = success ? TimeSpan.FromSeconds(maxAgeInSeconds) : null;
            }
        }
        return this;
    }
    public CacheController AddConstraints(CacheControlHeaderValue controlValues)
    {
        NoStore = controlValues.NoStore;
        MaxAge = controlValues.MaxAge;
        return this;
    }

    public bool OkToCache() => NoStore == false;

    public bool HasValidData(string ssn, out CreditData? creditData)
    {
        creditData = null;
        var cachedData = _dbService.GetData(ssn);
        if (cachedData == null) return false;

        if (NoStore || cachedData.CacheHasExpired() || cachedData.IsOlderThan(MaxAge))
        {
            _dbService.DeleteData(cachedData);
            return false;
        }

        creditData = cachedData;
        return true;
    }

    public static TimeSpan GetLimit(CacheControlHeaderValue cacheControl)
    {
        return cacheControl.MaxAge ?? new TimeSpan(0);
    }
}
