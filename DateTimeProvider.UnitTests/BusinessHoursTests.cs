using AwesomeAssertions;
using DateTimeProvider.Scenarios;
using DateTimeProvider.UnitTests.Extensions;

namespace DateTimeProvider.UnitTests;

public class BusinessHoursTests
{
    [Theory]
    [InlineData("2025-01-06 09:00", true)]   // Monday 9 AM
    [InlineData("2025-01-06 16:59", true)]   // Monday 4:59 PM
    [InlineData("2025-01-06 17:00", false)]  // Monday 5 PM (closed)
    [InlineData("2025-01-06 08:59", false)]  // Monday 8:59 AM (not yet)
    [InlineData("2025-01-04 12:00", false)]  // Saturday noon
    [InlineData("2025-01-05 12:00", false)]  // Sunday noon
    public void IsOpen_ReturnsCorrectResult(string currentTimeString, bool expectedOpen)
    {
        var currentTime = DateTime.Parse(currentTimeString);
        var dateTimeProvider = currentTime.CreateProvider();
        var businessHours = new BusinessHours(dateTimeProvider);

        var result = businessHours.IsOpen();

        result.Should().Be(expectedOpen);
    }
}
