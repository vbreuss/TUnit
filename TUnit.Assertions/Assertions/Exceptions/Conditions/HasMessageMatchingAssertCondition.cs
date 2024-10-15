using TUnit.Assertions.AssertConditions;
using TUnit.Assertions.Extensions;

namespace TUnit.Assertions.Assertions.Exceptions.Conditions;

internal class HasMessageMatchingAssertCondition<TException>(StringMatcher match)
    : DelegateAssertCondition<TException>
    where TException : Exception?
{
    protected override string GetExpectation()
        => $"which has Message matching \"{match.ToString()?.ShowNewLines().TruncateWithEllipsis(100)}\"";

    protected override Task<AssertionResult> GetResult(TException? actualValue, Exception? exception)
    {
        return AssertionResult
            .FailIf(
                () => actualValue is null,
                "the exception is null")
            .OrFailIf(
                () => !match.Matches(actualValue!.Message),
                $"found \"{actualValue!.Message.ShowNewLines().TruncateWithEllipsis(100)}\"");
    }
}