namespace TUnit.Assertions.AssertConditions;

internal static class SimpleAssertionBuilder
{
    public static BuilderWithExpectation<TActual> WithExpectation<TActual>(
        TActual expectedValue, Func<TActual, string> expectationGenerator)
    {
        return new BuilderWithExpectation<TActual>(expectedValue, expectationGenerator);
    }

    public class BuilderWithExpectation<TActual>(TActual expectedValue, Func<TActual, string> expectationGenerator)
    {
        public SimpleAssertCondition<TActual, TActual> FailIf(
            Func<TActual?, TActual?, bool> failIf,
        Func<TActual?, TActual?, string> failureMessageGenerator)
        {
            return new SimpleAssertCondition<TActual, TActual>(expectationGenerator(expectedValue), expectedValue, failIf, failureMessageGenerator);
        }
    }

    public class SimpleAssertCondition<TActual, TExpected>(
        string expectation,
        TExpected? expected,
        Func<TActual?, TExpected?, bool> failIf,
        Func<TActual?, TExpected?, string> failureMessageGenerator
    )
        : ExpectedValueAssertCondition<TActual, TExpected>(expected)
    {
        protected override string GetExpectation() => expectation;

        protected override AssertionResult GetResult(TActual? actualValue, TExpected? expectedValue)
            => AssertionResult.FailIf(
                () => failIf(actualValue, expectedValue),
                failureMessageGenerator(actualValue, expectedValue));
    }
}