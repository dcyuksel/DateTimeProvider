namespace DateTimeProvider;

public class DateTimeProvider(TimeProvider timeProvider) : IDateTimeProvider
{
    public DateTime Now => timeProvider.GetLocalNow().DateTime;
    public DateOnly Today => DateOnly.FromDateTime(Now);
    public DateTime UtcNow => timeProvider.GetUtcNow().DateTime;
}