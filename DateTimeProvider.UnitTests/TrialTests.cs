using AwesomeAssertions;
using DateTimeProvider.Scenarios;
using DateTimeProvider.UnitTests.Extensions;

namespace DateTimeProvider.UnitTests;

public class TrialTests
{
    [Theory]
    [InlineData("2025-01-01", "2025-01-01", true, 0)]    // Day 1
    [InlineData("2025-01-01", "2025-01-07", true, 6)]    // Day 7
    [InlineData("2025-01-01", "2025-01-14", true, 13)]   // Day 14 (last day)
    [InlineData("2025-01-01", "2025-01-15", false, 14)]  // Day 15 (expired)
    [InlineData("2025-01-01", "2025-02-01", false, 31)]  // Long expired
    public void TrialPeriod(
        string startedOnString,
        string todayString,
        bool expectedActive,
        int expectedDaysUsed)
    {
        var startedOn = DateOnly.Parse(startedOnString);
        var today = DateOnly.Parse(todayString);
        var dateTimeProvider = today.CreateProvider();
        var trial = new Trial(startedOn, dateTimeProvider);

        trial.IsActive.Should().Be(expectedActive);
        trial.DaysUsed.Should().Be(expectedDaysUsed);
    }
}