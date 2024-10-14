using System.Runtime.CompilerServices;
using TUnit.Assertions.AssertConditions.Interfaces;
using TUnit.Assertions.AssertConditions.Throws;
using TUnit.Assertions.AssertionBuilders;

namespace TUnit.Assertions.Extensions;

public static class ExceptionExtensions
{
    public static InvokableValueAssertionBuilder<TException?> HasMessage<TException>(this IValueSource<TException?> valueSource, string expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue1 = "")
        where TException : Exception
    {
        return valueSource.RegisterAssertion(
            new ThrowsWithMessageAssertCondition<TException?, TException?>(expected, StringComparison.Ordinal, e => e)
            , [doNotPopulateThisValue1]);
    }
    public static InvokableValueAssertionBuilder<TException?> HasHResult<TException>(this IValueSource<TException?> valueSource, int expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue1 = "")
        where TException : Exception
    {
        return valueSource.RegisterAssertion(
            new ThrowsWithHResultAssertCondition<TException?, TException?>(expected, StringComparison.Ordinal, e => e)
            , [doNotPopulateThisValue1]);
    }

    //public static InvokableValueAssertionBuilder<TException?> HasInnerException<TException>(this IValueSource<TException?> valueSource, string expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue1 = "")
    //    where TException : Exception
    //{
    //    return valueSource.RegisterAssertion(
    //        new ThrowsWithMessageAssertCondition<TException?, TException?>(expected, StringComparison.Ordinal, e => e)
    //        , [doNotPopulateThisValue1]);
    //}
}