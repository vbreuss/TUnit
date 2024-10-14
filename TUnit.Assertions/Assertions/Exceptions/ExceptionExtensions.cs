using System.Runtime.CompilerServices;
using TUnit.Assertions.AssertConditions;
using TUnit.Assertions.AssertConditions.Interfaces;
using TUnit.Assertions.AssertConditions.Throws;
using TUnit.Assertions.AssertionBuilders;
using TUnit.Assertions.Assertions.Exceptions.Conditions;

namespace TUnit.Assertions.Extensions;

public static class ExceptionExtensions
{
    public static InvokableValueAssertionBuilder<TException?> HasMessage<TException>(this IValueSource<TException?> source, string expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue1 = "")
        where TException : Exception
    {
        return source.RegisterAssertion(
            new HasMessageAssertCondition<TException?>(expected, StringComparison.Ordinal),
            [doNotPopulateThisValue1]);
    }

    public static InvokableValueAssertionBuilder<TException?> HasMessageMatching<TException>(this IValueSource<TException?> source, StringMatcher match, [CallerArgumentExpression("match")] string doNotPopulateThisValue1 = "")
        where TException : Exception
    {
        return source.RegisterAssertion(new HasMessageMatchingAssertCondition<TException?>(match),
            [doNotPopulateThisValue1]);
    }
    public static InvokableValueAssertionBuilder<TException?> HasHResult<TException>(this IValueSource<TException?> valueSource, int expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue1 = "")
        where TException : Exception
    {
        return valueSource.RegisterAssertion(
            new HasHResultAssertCondition<TException?>(expected),
            [doNotPopulateThisValue1]);
    }

    //public static InvokableValueAssertionBuilder<TException?> HasInnerException<TException>(this IValueSource<TException?> valueSource)
    //    where TException : Exception
    //{
    //    return valueSource.RegisterAssertion(
    //        new ThrowsWithMessageAssertCondition<TException?, TException?>(expected, StringComparison.Ordinal, e => e)
    //        , [doNotPopulateThisValue1]);
    //}
}