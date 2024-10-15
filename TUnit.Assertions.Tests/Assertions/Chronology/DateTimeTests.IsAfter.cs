namespace TUnit.Assertions.Tests.Assertions.Chronology;

public sealed partial class DateTimeTests
{
    public sealed class IsAfter
    {
        [Test]
        public async Task Does_Not_Throw_For_Later_Time()
        {
            var expected = CurrentTime();
            var sut = LaterTime();

            var action = async () => await Assert.That(sut).IsAfter(expected);

            await Assert.That(action).ThrowsNothing();
        }

        [Test]
        public async Task Does_Throw_For_Earlier_Time()
        {
            var expected = CurrentTime();
            var sut = EarlierTime();
            string expectedMessage = $"""
                Expected sut to be after {expected:O}
                
                but found {sut:O}
                
                at Assert.That(sut).IsAfter(expected)
                """;

            var action = async () => await Assert.That(sut).IsAfter(expected);

            await Assert.That(action).ThrowsException().WithMessage(expectedMessage);
        }

        [Test]
        public async Task Does_Throw_For_Same_Time()
        {
            var expected = CurrentTime();
            var sut = CurrentTime();
            string expectedMessage = $"""
                Expected sut to be after {expected:O}
                
                but found {sut:O}
                
                at Assert.That(sut).IsAfter(expected)
                """;

            var action = async () => await Assert.That(sut).IsAfter(expected);

            await Assert.That(action).ThrowsException().WithMessage(expectedMessage);
        }
    }
}
