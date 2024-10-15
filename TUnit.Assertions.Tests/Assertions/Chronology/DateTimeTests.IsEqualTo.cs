namespace TUnit.Assertions.Tests.Assertions.Chronology;

public sealed partial class DateTimeTests
{
    public sealed class IsEqualTo
    {
        [Test]
        public async Task Does_Not_Throw_For_Equal_Values()
        {
            var expected = CurrentTime();
            var sut = CurrentTime();

            var action = async () => await Assert.That(sut).IsEqualTo(expected);

            await Assert.That(action).ThrowsNothing();
        }

        [Test]
        public async Task Does_Throw_For_Different_Times()
        {
            var expected = CurrentTime();
            var sut = EarlierTime();
            string expectedMessage = $"""
                Expected sut to be equal to {expected:O}
                
                but found {sut:O}
                
                at Assert.That(sut).IsEqualTo(expected)
                """;

            var action = async () => await Assert.That(sut).IsEqualTo(expected);

            await Assert.That(action).ThrowsException().WithMessage(expectedMessage);
        }
    }
}
