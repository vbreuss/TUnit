using TUnit.Assertions.AssertConditions;
using TUnit.Assertions.Extensions;
using TUnit.Assertions.Helpers;

namespace TUnit.Assertions.Assertions.Exceptions.Conditions;

internal class HasMessageAssertCondition<TException>(string expectedMessage, StringComparison stringComparison)
    : DelegateAssertCondition<TException, Exception>
    where TException : Exception?
{
    protected override string GetExpectation()
        => $"which has Message equal to \"{expectedMessage.ShowNewLines().TruncateWithEllipsis(100)}\"";

    protected override Task<AssertionResult> GetResult(TException? actualValue, Exception? exception)
    {
        return AssertionResult
            .FailIf(
                () => actualValue is null,
                "the exception is null")
            .OrFailIf(
                () => !string.Equals(actualValue!.Message, expectedMessage, stringComparison),
                new StringDifference(actualValue!.Message, expectedMessage)
                    .ToString("it differs at index"));
    }
}