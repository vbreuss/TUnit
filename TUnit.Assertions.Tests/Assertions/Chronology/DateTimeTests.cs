namespace TUnit.Assertions.Tests.Assertions.Chronology;

public sealed partial class DateTimeTests
{
    /// <summary>
    /// Use a fixed random time in each test run to ensure, that the tests don't rely on special times.
    /// </summary>
    private static readonly Lazy<DateTime> CurrentTimeLazy = new(
        () => new DateTime(
            Random.Shared.NextInt64(DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks),
            DateTimeKind.Utc));

    private static DateTime EarlierTime()
        => CurrentTime().AddSeconds(-1);

    private static DateTime CurrentTime()
        => CurrentTimeLazy.Value;

    private static DateTime LaterTime()
        => CurrentTime().AddSeconds(1);
}
