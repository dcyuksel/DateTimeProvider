namespace DateTimeProvider.Scenarios;

public class Subscription(DateOnly expiresOn, IDateTimeProvider dateTimeProvider)
{
    public DateOnly ExpiresOn { get; } = expiresOn;

    public bool IsExpired => dateTimeProvider.Today > ExpiresOn;

    public int DaysRemaining => IsExpired
        ? 0
        : ExpiresOn.DayNumber - dateTimeProvider.Today.DayNumber;
}