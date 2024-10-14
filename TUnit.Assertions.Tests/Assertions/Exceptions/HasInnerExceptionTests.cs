namespace TUnit.Assertions.Tests.Assertions.Exceptions;

public class HasInnerExceptionTests
{
    [Test]
    public async Task Fails_For_Different_Messages_In_Inner_Exception()
    {
        var outerMessage = "foo";
        var expectedInnerMessage = "bar";
        var expectedMessage = """
                              Expected action to throw an Exception which message equals "bar"

                              but it differs at index 0:
                                  ↓
                                 "some different inner message"
                                 "bar"
                                  ↑

                              at Assert.That(action).ThrowsException().Which.HasInnerException(e => e.HasMessage(expectedInnerMessage))
                              """;
        Exception exception = new(outerMessage, new("some different inner message"));
        Action action = () => throw exception;

        var sut = async ()
            => await Assert.That(action).ThrowsException().Which
                .HasInnerException(e => e.HasMessage(expectedInnerMessage));

        await Assert.That(sut).ThrowsException()
            .WithMessage(expectedMessage);
    }

    [Test]
    public async Task Returns_Exception_When_Awaited()
    {
        Exception exception = new("", new());
        Action action = () => throw exception;

        var result = await Assert.That(action).ThrowsException().Which
            .HasInnerException(e1 => e1.HasMessageMatching("*"));

        await Assert.That((object?)result).IsSameReference(exception);
    }

    [Test]
    public async Task Succeed_For_Matching_Message()
    {
        var outerMessage = "foo";
        var innerMessage = "bar";
        Exception exception = new(outerMessage, new(innerMessage));
        Action action = () => throw exception;

        var sut = async ()
            => await Assert.That(action).ThrowsException()
                .Which.HasInnerException(e => e.HasMessage(innerMessage));

        await Assert.That(sut).ThrowsNothing();
    }
}
