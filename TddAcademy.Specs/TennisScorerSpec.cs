using FluentAssertions;
using Xbehave;

namespace TddAcademy.Specs
{
	public class TennisScorerSpec
	{
		// todo: reset after finishing a game? 

		[Scenario]
		public void PlayerAWinsAGame(TennisScorer scorer)
		{
			"Given a game starts"
				.x(() => scorer = new TennisScorer(new TennisCounter(), new TennisNaming()));
			"When a player A has 3 points"
				.x(() =>
				{
					scorer.ScorePlayerA();
					scorer.ScorePlayerA();
					scorer.ScorePlayerA();
				});
			"And player B has 2 points"
				.x(() =>
				{
					scorer.ScorePlayerB();
					scorer.ScorePlayerB();
				});
			"And player A scores"
				.x(() => scorer.ScorePlayerA());
			"Then player A wins the game"
				.x(() => scorer.Score.Should().Be("game A"));
		}

		[Scenario]
		public void PlayerAScoresFirstPoint(TennisScorer scorer)
		{
			"Given a game starts"
				.x(() => scorer = new TennisScorer(new TennisCounter(), new TennisNaming()));
			"When a player A has 1 point and player B has 0 points"
				.x(() =>
				{
					scorer.ScorePlayerA();
				});
			"Then the score is named 'fifteen:love'"
				.x(() => scorer.Score.Should().Be("fifteen:love"));
		}
	}
}
