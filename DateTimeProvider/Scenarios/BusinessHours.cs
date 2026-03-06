namespace DateTimeProvider.Scenarios;

public class BusinessHours(IDateTimeProvider dateTimeProvider)
{
    public bool IsOpen()
    {
        var now = dateTimeProvider.Now;
        var hour = now.Hour;
        var dayOfWeek = dateTimeProvider.Today.DayOfWeek;

        var isWeekday = dayOfWeek is not DayOfWeek.Saturday and not DayOfWeek.Sunday;
        var isDuringHours = hour is >= 9 and < 17;

        return isWeekday && isDuringHours;
    }
}
