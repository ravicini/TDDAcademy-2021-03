using FakeItEasy;

namespace TddAcademy.Specs
{
	using FluentAssertions;
	using Xbehave;

	public class TennisScorerSpec
	{
		private Foo foo;

		[Background]
		public void Background()
		{
			this.foo = new Foo(new Bar());
		}

		[Scenario]
		public void PlayerAWinsGame(TennisScorer scorer)
		{
			"Given the scorer"
				.x(() => scorer = new TennisScorer(new ScoreAnalyzer(new ScoreTranslator())));

			"When player A scores"
				.x(() => scorer.ScorePlayerA());

			"When player B scores"
				.x(() => scorer.ScorePlayerB());

			"Then the score is fifteen:fifteen"
				.x(() => scorer.Score.Should().Be("fifteen:fifteen"));

			"When player A scores"
				.x(() => scorer.ScorePlayerA());

			"When player A scores"
				.x(() => scorer.ScorePlayerA());

			"When player A scores"
				.x(() => scorer.ScorePlayerA());

			"Then player A wins this game"
				.x(() => scorer.Score.Should().Be("game A"));
		}
	}
}
