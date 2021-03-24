using System.Security;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
    public class ScoreBuilderFact
    {
        [Theory]
        [InlineData(0, 0, "love:love")]
        [InlineData(2, 0, "thirty:love")]
        [InlineData(2, 2, "thirty:thirty")]
        [InlineData(2, 3, "thirty:forty")]
        [InlineData(4, 2, "game A")]
        [InlineData(3, 3, "deuce")]
        [InlineData(4, 3, "advantage A")]
        [InlineData(6, 6, "deuce")]
        [InlineData(7, 8, "advantage B")]
        [InlineData(9, 11, "game B")]
        public void ShouldConvertPlayerScoresToString(int playerAScore, int playerBScore, string expected)
        {
            var scoreBuilder = new ScoreBuilder();
            var playerA = A.Fake<IPlayer>();
            var playerB = A.Fake<IPlayer>();

            A.CallTo(() => playerA.CurrentScore).Returns(playerAScore);
            A.CallTo(() => playerB.CurrentScore).Returns(playerBScore);

            var result = scoreBuilder.BuildScoreString(playerA, playerB);

            result.Should().Be(expected);
        }
    }
}