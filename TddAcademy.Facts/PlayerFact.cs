using FluentAssertions;
using Newtonsoft.Json.Bson;
using Xunit;

namespace TddAcademy.Facts
{
    public class PlayerFact
    {
        [Fact]
        public void CurrentScoreShouldIncrease()
        {
            var player = new Player();
            var currentScore = player.CurrentScore;

            player.Scored();

            player.CurrentScore.Should().Be(currentScore + 1);
        }
    }
}