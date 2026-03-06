namespace DateTimeProvider.Scenarios;

public class Trial(DateOnly startedOn, IDateTimeProvider dateTimeProvider)
{
    private const int TrialDays = 14;

    public DateOnly StartedOn { get; } = startedOn;

    public bool IsActive => dateTimeProvider.Today < StartedOn.AddDays(TrialDays);
    public int DaysUsed => dateTimeProvider.Today.DayNumber - StartedOn.DayNumber;
}
