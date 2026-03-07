using AwesomeAssertions;
using DateTimeProvider.Scenarios;
using DateTimeProvider.UnitTests.Extensions;

namespace DateTimeProvider.UnitTests;

public class SubscriptionTests
{
    [Theory]
    [InlineData("2025-01-01", "2025-01-02", true)]   // Expired yesterday
    [InlineData("2025-01-01", "2025-01-01", false)]  // Expires today (still valid)
    [InlineData("2025-01-01", "2024-12-31", false)]  // Expires tomorrow
    [InlineData("2025-06-15", "2025-06-16", true)]   // Expired
    [InlineData("2025-06-15", "2025-06-14", false)]  // Still valid
    public void IsExpired(
        string expiresOnString,
        string todayString,
        bool expectedExpired)
    {
        var expiresOn = DateOnly.Parse(expiresOnString);
        var today = DateOnly.Parse(todayString);
        var dateTimeProvider = today.CreateProvider();
        var subscription = new Subscription(expiresOn, dateTimeProvider);

        var result = subscription.IsExpired;

        result.Should().Be(expectedExpired);
    }

    [Theory]
    [InlineData("2025-01-10", "2025-01-01", 9)]   // 9 days remaining
    [InlineData("2025-01-10", "2025-01-09", 1)]   // 1 day remaining
    [InlineData("2025-01-10", "2025-01-10", 0)]   // Last day
    [InlineData("2025-01-10", "2025-01-15", 0)]   // Already expired
    public void DaysRemaining(
        string expiresOnString,
        string todayString,
        int expectedDays)
    {
        var expiresOn = DateOnly.Parse(expiresOnString);
        var today = DateOnly.Parse(todayString);
        var dateTimeProvider = today.CreateProvider();
        var subscription = new Subscription(expiresOn, dateTimeProvider);

        var result = subscription.DaysRemaining;

        result.Should().Be(expectedDays);
    }
}