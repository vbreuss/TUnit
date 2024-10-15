namespace TUnit.Assertions.Tests.Assertions.Chronology;

public sealed partial class DateTimeTests
{
    public sealed class IsOnOrAfter
    {
        [Test]
        public async Task Does_Not_Throw_For_Later_Time()
        {
            var expected = CurrentTime();
            var sut = LaterTime();

            var action = async () => await Assert.That(sut).IsOnOrAfter(expected);

            await Assert.That(action).ThrowsNothing();
        }

        [Test]
        public async Task Does_Not_Throw_For_Same_Time()
        {
            var expected = CurrentTime();
            var sut = CurrentTime();

            var action = async () => await Assert.That(sut).IsOnOrAfter(expected);

            await Assert.That(action).ThrowsNothing();
        }

        [Test]
        public async Task Does_Throw_For_Earlier_Time()
        {
            var expected = CurrentTime();
            var sut = EarlierTime();
            string expectedMessage = $"""
                Expected sut to be on or after {expected:O}
                
                but found {sut:O}
                
                at Assert.That(sut).IsOnOrAfter(expected)
                """;

            var action = async () => await Assert.That(sut).IsOnOrAfter(expected);

            await Assert.That(action).ThrowsException().WithMessage(expectedMessage);
        }
    }
}
