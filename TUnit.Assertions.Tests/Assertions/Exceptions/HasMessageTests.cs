namespace TUnit.Assertions.Tests.Assertions.Exceptions;

public class HasMessageTests
{
    [Test]
    public async Task Fails_For_Different_Messages()
    {
        var message1 = "foo";
        var message2 = "bar";
        var expectedMessage = """
                              Expected action to throw an Exception which message equals "bar"

                              but it differs at index 0:
                                  ↓
                                 "foo"
                                 "bar"
                                  ↑

                              at Assert.That(action).ThrowsException().Which.HasMessage(message2)
                              """;
        Exception exception = new(message1);
        Action action = () => throw exception;

        var sut = async ()
            => await Assert.That(action).ThrowsException().Which.HasMessage(message2);

        await Assert.That(sut).ThrowsException()
            .WithMessage(expectedMessage);
    }

    [Test]
    public async Task Returns_Exception_When_Awaited()
    {
        var matchingMessage = "foo";
        Exception exception = new(matchingMessage);
        Action action = () => throw exception;

        var result = await Assert.That(action).ThrowsException().Which.HasMessage(matchingMessage);

        await Assert.That((object?)result).IsSameReference(exception);
    }

    [Test]
    public async Task Succeed_For_Matching_Message()
    {
        var matchingMessage = "foo";
        Exception exception = new(matchingMessage);
        Action action = () => throw exception;

        var sut = async ()
            => await Assert.That(action).ThrowsException().Which.HasMessage(matchingMessage);

        await Assert.That(sut).ThrowsNothing();
    }
}
