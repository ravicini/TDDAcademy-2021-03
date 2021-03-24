using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
	public class TennisScorerFact
	{
		#region Fields

		private readonly ITennisCounter _counter;
		private readonly ITennisNaming _naming;
		private readonly TennisScorer _testee;

		#endregion

		public TennisScorerFact()
		{
			_counter = A.Fake<ITennisCounter>();
			_naming = A.Fake<ITennisNaming>();
			_testee = new TennisScorer(_counter, _naming);
		}

		[Fact]
		public void TennisScorer_ShouldCall_CounterPlayerAScore()
		{
			_testee.ScorePlayerA();

			A.CallTo(() => _counter.PlayerAScore())
			 .MustHaveHappened(1, Times.Exactly);
		}

		[Fact]
		public void TennisScorer_ShouldCall_CounterPlayerBScore()
		{
			_testee.ScorePlayerB();

			A.CallTo(() => _counter.PlayerBScore())
			 .MustHaveHappened(1, Times.Exactly);
		}

		[Fact]
		public void TennisScorer_ShouldCall_NamingScore()
		{
			A.CallTo(() => _counter.PointsPlayerA).Returns(1);
			A.CallTo(() => _counter.PointsPlayerB).Returns(2);
			A.CallTo(() => _naming.GetNameByScore(1, 2))
			 .Returns("myReturn");

			_testee.Score.Should().Be("myReturn");
		}
	}
}
