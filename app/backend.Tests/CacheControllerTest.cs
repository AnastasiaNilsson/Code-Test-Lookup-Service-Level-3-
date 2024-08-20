namespace backend.Tests;

public class CacheControllerTest
{
    private IDbService _dbService = new MockDbService();


    [Fact]
    public void Caching_ShouldBeAcceptedByDefault()
    {
        // Arrange
        var controller = new CacheController(_dbService);
        var controlValues = new CacheControlHeaderValue();

        // Act
        controller.AddConstraints(controlValues);
        var okToCache = controller.OkToCache();

        // Assert
        okToCache.Should().Be(true);
    }

    [Fact]
    public void NoStoreControlValue_ShouldPreventCaching()
    {
        // Arrange
        var controller = new CacheController(_dbService);
        var controlValues = new CacheControlHeaderValue()
        {
            NoStore = true
        };

        // Act
        controller.AddConstraints(controlValues);
        var okToCache = controller.OkToCache();

        // Assert
        okToCache.Should().Be(false);
    }

    [Fact]
    public void CacheLimitOnData_ShouldAllowUseOfCachedData_IfWithinLimit()
    {
        // Arrange
        var controller = new CacheController(_dbService);
        var controlValues = new CacheControlHeaderValue();
        var socialSecurityNumber = "19871222-3950";
            // Credot data for this SSN is still within the caching limit

        // Act
        controller.AddConstraints(controlValues);
        var okToUseCachedData = controller.HasValidData(socialSecurityNumber, out var _);

        // Assert
        okToUseCachedData.Should().Be(true);
    }

    [Fact]
    public void CacheLimitOnData_ShouldPreventUseOfCachedData_IfTooLow()
    {
        // Arrange
        var controller = new CacheController(_dbService);
        var controlValues = new CacheControlHeaderValue();
        var socialSecurityNumber = "19851223-3951"; 
            // Credot data for this SSN has been stored for longer than the caching limit

        // Act
        controller.AddConstraints(controlValues);
        var okToUseCachedData = controller.HasValidData(socialSecurityNumber, out var _);

        // Assert
        okToUseCachedData.Should().Be(false);
    }

    [Fact]
    public void MaxAgeControlValue_ShouldPreventUseOfCachedData_IfTooLow()
    {
        // Arrange
        var controller = new CacheController(_dbService);
        var controlValues = new CacheControlHeaderValue()
        {
            MaxAge = TimeSpan.FromSeconds(50)
        };
        var socialSecurityNumber = "19871222-3950";
            // Credot data for this SSN is still within the caching limit

        // Act
        controller.AddConstraints(controlValues);
        var okToUseCachedData = controller.HasValidData(socialSecurityNumber, out var _);

        // Assert
        okToUseCachedData.Should().Be(false);
    }
}
