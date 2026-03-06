using Microsoft.Extensions.Time.Testing;

namespace DateTimeProvider.UnitTests.Extensions;

public static class DateTimeTestingExtensions
{
    extension(DateOnly date)
    {
        public DateTimeProvider CreateProvider()
        {
            var fakeTimeProvider = new FakeTimeProvider(date.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc));

            return new DateTimeProvider(fakeTimeProvider);
        }
    }

    extension(DateTime dateTime)
    {
        public DateTimeProvider CreateProvider()
        {
            var fakeTimeProvider = new FakeTimeProvider(dateTime);

            return new DateTimeProvider(fakeTimeProvider);
        }
    }
}
