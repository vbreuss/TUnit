namespace TUnit.Assertions.Tests.Assertions.Chronology;

public sealed partial class DateTimeTests
{
    public sealed class IsOnOrBefore
    {
        [Test]
        public async Task Does_Not_Throw_For_Earlier_Time()
        {
            var expected = CurrentTime();
            var sut = EarlierTime();

            var action = async () => await Assert.That(sut).IsOnOrBefore(expected);

            await Assert.That(action).ThrowsNothing();
        }

        [Test]
        public async Task Does_Not_Throw_For_Same_Time()
        {
            var expected = CurrentTime();
            var sut = CurrentTime();

            var action = async () => await Assert.That(sut).IsOnOrBefore(expected);

            await Assert.That(action).ThrowsNothing();
        }

        [Test]
        public async Task Does_Throw_For_Later_Time()
        {
            var expected = CurrentTime();
            var sut = LaterTime();
            string expectedMessage = $"""
                Expected sut to be on or before {expected:O}
                
                but found {sut:O}
                
                at Assert.That(sut).IsOnOrBefore(expected)
                """;

            var action = async () => await Assert.That(sut).IsOnOrBefore(expected);

            await Assert.That(action).ThrowsException().WithMessage(expectedMessage);
        }
    }
}
