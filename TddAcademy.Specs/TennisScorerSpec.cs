using FluentAssertions;
using TddAcademy.Facts;
using Xbehave;

namespace TddAcademy.Specs
{
    public class TennisScorerSpec
    {
        [Scenario]
        public void PlayerAIsWinning(ITennisScorer tennisScorer)
        {
            const string expectedFirstScore = "fifteen:love";
            const string expectedSecondScore = "fifteen:fifteen";
            const string expectedFinalScore = "game A";

            "Given Player A and Player B have started a game".x(() => tennisScorer = new TennisScorer(
                new Player(),
                new Player(),
                new ScoreBuilder()
                ));
            "And Player A has scored a point".x(() => tennisScorer.ScorePlayerA());
            $"Then the score is {expectedFirstScore}".x(() => tennisScorer.Score.Should().Be(expectedFirstScore));
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            $"Then the score is {expectedSecondScore}".x(() => tennisScorer.Score.Should().Be(expectedSecondScore));
            "And Player A has scored a point".x(() => tennisScorer.ScorePlayerA());
            "And Player A has scored a point".x(() => tennisScorer.ScorePlayerA());
            "And Player A has scored a point".x(() => tennisScorer.ScorePlayerA());
            $"Then the score is {expectedFinalScore}".x(() => tennisScorer.Score.Should().Be(expectedFinalScore));
        }

        [Scenario]
        public void PlayerBIsWinning(ITennisScorer tennisScorer)
        {
            const string expectedFirstScore = "love:forty";
            const string expectedFinalScore = "game B";

            "Given Player A and Player B have started a game".x(() => tennisScorer = new TennisScorer(
                new Player(),
                new Player(),
                new ScoreBuilder()
            ));
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            $"Then the score is {expectedFirstScore}".x(() => tennisScorer.Score.Should().Be(expectedFirstScore));
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            $"Then the score is {expectedFinalScore}".x(() => tennisScorer.Score.Should().Be(expectedFinalScore));
        }

        [Scenario]
        public void PlayerBIsWinningAfterAHardFight(ITennisScorer tennisScorer)
        {
            const string expectedFirstScore = "thirty:thirty";
            const string expectedEqualScore = "deuce";
            const string expectedAdvantageA = "advantage A";
            const string expectedAdvantageB = "advantage B";
            const string expectedFinalScore = "game B";

            "Given Player A and Player B have started a game".x(() => tennisScorer = new TennisScorer(
                new Player(),
                new Player(),
                new ScoreBuilder()
            ));
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            "And Player A has scored a point".x(() => tennisScorer.ScorePlayerA());
            "And Player A has scored a point".x(() => tennisScorer.ScorePlayerA());
            $"Then the score is {expectedFirstScore}".x(() => tennisScorer.Score.Should().Be(expectedFirstScore));
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            "And Player A has scored a point".x(() => tennisScorer.ScorePlayerA());
            $"Then the score is {expectedEqualScore}".x(() => tennisScorer.Score.Should().Be(expectedEqualScore));
            "And Player A has scored a point".x(() => tennisScorer.ScorePlayerA());
            $"Then the score is {expectedAdvantageA}".x(() => tennisScorer.Score.Should().Be(expectedAdvantageA));
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            $"Then the score is {expectedEqualScore}".x(() => tennisScorer.Score.Should().Be(expectedEqualScore));
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            $"Then the score is {expectedAdvantageB}".x(() => tennisScorer.Score.Should().Be(expectedAdvantageB));
            "And Player B has scored a point".x(() => tennisScorer.ScorePlayerB());
            $"Then the score is {expectedFinalScore}".x(() => tennisScorer.Score.Should().Be(expectedFinalScore));
        }

        [Scenario]
        public void RefereeMakesPlayerAWin()
        {
            "Given a Referee, Player A and Player B have started a game".x(() => { });
            "The Referee gives a point to Player A".x(() => { });
            "Then the scoreboard gets notified".x(() => { });
        }
    }
}