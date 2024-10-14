namespace TUnit.Assertions.Tests.Assertions.Exceptions;

public class HasHResultTests
{
    [Test]
    public async Task And_Or_Precedence_Test()
    {
        char[] sut = "CD".ToCharArray();

        await Assert.That(sut)
            .Contains('A').And
            .Contains('B').Or
            .Contains('C').And
            .Contains('D');
    }

    [Test]
    public async Task Fails_For_Different_HResults()
    {
        var actual = 1001;
        var expected = 9876;
        var expectedMessage = """
                              Expected action to throw an Exception which HResult equals 9876

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

    [Test]
    public async Task Succeed_For_Matching_HResults()
    {
        var matching = 1234;
        Exception exception = new() { HResult = matching };
        Action action = () => throw exception;

        var result = await Assert.That(action).ThrowsException().Which.HasHResult(matching);

        await Assert.That((object?)result).IsSameReference(exception);
    }
}
