#nullable disable

using System.Runtime.CompilerServices;
using TUnit.Assertions.AssertConditions;
using TUnit.Assertions.AssertConditions.Chronology;
using TUnit.Assertions.AssertConditions.Interfaces;
using TUnit.Assertions.AssertionBuilders;
using TUnit.Assertions.AssertionBuilders.Wrappers;

namespace TUnit.Assertions.Extensions;

public static class DateTimeIsExtensions
{
    /// <summary>
    /// Asserts that the current <see cref="DateTime"/> <paramref name="value" /> is exactly equal to the <paramref name="expected"/> value.
    /// </summary>
    public static DateTimeEqualToAssertionBuilderWrapper IsEqualTo(this IValueSource<DateTime> value, DateTime expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue1 = "")
    {
        return new DateTimeEqualToAssertionBuilderWrapper(
            value.RegisterAssertion(new DateTimeEqualsExpectedValueAssertCondition(expected),
                [doNotPopulateThisValue1])
        );
    }

    /// <summary>
    /// Asserts that the current <see cref="DateTime"/> <paramref name="value" /> is after the specified <paramref name="expected"/> value.
    /// </summary>
    public static InvokableValueAssertionBuilder<DateTime> IsAfter(this IValueSource<DateTime> value, DateTime expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
    {
        return value.RegisterAssertion(SimpleAssertionBuilder
            .WithExpectation(expected, _ => $"to be after {expected:O}")
            .FailIf(
                (actualValue, expectedValue) => actualValue <= expectedValue,
                (actualValue, _) => $"found {actualValue:O}")
            , [doNotPopulateThisValue]);
    }

    /// <summary>
    /// Asserts that the current <see cref="DateTime"/> <paramref name="value" /> is on or after the specified <paramref name="expected"/> value.
    /// </summary>
    public static InvokableValueAssertionBuilder<DateTime> IsOnOrAfter(this IValueSource<DateTime> value, DateTime expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
    {
        return value.RegisterAssertion(SimpleAssertionBuilder
            .WithExpectation(expected, _ => $"to be on or after {expected:O}")
            .FailIf(
                (actualValue, expectedValue) => actualValue < expectedValue,
                (actualValue, _) => $"found {actualValue:O}")
            , [doNotPopulateThisValue]);
    }

    /// <summary>
    /// Asserts that the current <see cref="DateTime"/> <paramref name="value" /> is before the specified <paramref name="expected"/> value.
    /// </summary>
    public static InvokableValueAssertionBuilder<DateTime> IsBefore(this IValueSource<DateTime> value, DateTime expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
    {
        return value.RegisterAssertion(SimpleAssertionBuilder
            .WithExpectation(expected, _ => $"to be before {expected:O}")
            .FailIf(
                (actualValue, expectedValue) => actualValue >= expectedValue,
                (actualValue, _) => $"found {actualValue:O}")
            , [doNotPopulateThisValue]);
    }

    /// <summary>
    /// Asserts that the current <see cref="DateTime"/> <paramref name="value" /> is on or before the specified <paramref name="expected"/> value.
    /// </summary>
    public static InvokableValueAssertionBuilder<DateTime> IsOnOrBefore(this IValueSource<DateTime> value,
        DateTime expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
    {
        return value.RegisterAssertion(SimpleAssertionBuilder
            .WithExpectation(expected, _ => $"to be on or before {expected:O}")
            .FailIf(
                (actualValue, expectedValue) => actualValue > expectedValue,
                (actualValue, _) => $"found {actualValue:O}")
            , [doNotPopulateThisValue]);
    }
}