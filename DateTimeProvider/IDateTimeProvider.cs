namespace DateTimeProvider;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    DateOnly Today { get; }
    DateTime UtcNow { get; }
}