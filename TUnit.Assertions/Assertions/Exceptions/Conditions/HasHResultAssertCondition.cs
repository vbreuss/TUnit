using TUnit.Assertions.AssertConditions;
using TUnit.Assertions.Extensions;

namespace TUnit.Assertions.Assertions.Exceptions.Conditions;

internal class HasHResultAssertCondition<TException>(int expected)
    : DelegateAssertCondition<TException, Exception>
    where TException : Exception?
{
    protected override string GetExpectation()
        => $"to throw {typeof(TException).Name.PrependAOrAn()} which HResult equals {expected}";

    protected override Task<AssertionResult> GetResult(TException? actualValue, Exception? exception)
    {
        return AssertionResult
            .FailIf(
                () => actualValue is null,
                "the exception is null")
            .OrFailIf(
                () => actualValue!.HResult != expected,
                $"found {actualValue!.HResult}");
    }
}