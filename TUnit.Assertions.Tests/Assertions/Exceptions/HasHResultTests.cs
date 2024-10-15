namespace TUnit.Assertions.Tests.Assertions.Exceptions;

public class HasHResultTests
{
    [Test]
    public async Task Fails_For_Different_HResults()
    {
        var actual = 1001;
        var expected = 9876;
        var expectedMessage = """
                              Expected exception which has HResult equal to 9876

                              but found 1001

                              at Assert.That(exception).HasHResult(expected)
                              """;
        Exception exception = new() { HResult = actual };

        var sut = async () => await Assert.That(exception).HasHResult(expected);

        await Assert.That(sut).ThrowsException()
            .WithMessage(expectedMessage);
    }

    [Test]
    public async Task Succeed_For_Matching_HResults()
    {
        var matching = 1234;
        Exception exception = new() { HResult = matching };

        var result = await Assert.That(exception).HasHResult(matching);

        await Assert.That((object?)result).IsSameReference(exception);
    }

    [Test]
    public async Task Supports_Throw_Delegates()
    {
        var actual = 1001;
        var expected = 9876;
        var expectedMessage = """
                              Expected action to throw an Exception which has HResult equal to 9876

                              but found 1001

                              at Assert.That(action).ThrowsException().Which.HasHResult(expected)
                              """;
        Exception exception = new() { HResult = actual };
        Action action = () => throw exception;

        var sut = async ()
            => await Assert.That(action).ThrowsException().Which.HasHResult(expected);

        await Assert.That(sut).ThrowsException()
            .WithMessage(expectedMessage);
    }
}
