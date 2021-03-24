using FakeItEasy;
using Xunit;

namespace TddAcademy.Facts
{
	// todo: numbers > 3 -> advanced score
	// todo: deuce
	// todo: advantage
	public class ScoreAnalyzerFact
	{
		#region Fields

		private readonly IScoreTranslator _scoreTranslatorFake;
		private readonly ScoreAnalyzer _testee;

		#endregion

		public ScoreAnalyzerFact()
		{
			_scoreTranslatorFake = A.Fake<IScoreTranslator>();
			_testee = new ScoreAnalyzer(_scoreTranslatorFake);
		}

		[Theory]
		[InlineData(0, 0)]
		[InlineData(1, 0)]
		[InlineData(2, 0)]
		[InlineData(3, 0)]
		[InlineData(0, 1)]
		[InlineData(0, 2)]
		[InlineData(0, 3)]
		[InlineData(1, 1)]
		[InlineData(2, 1)]
		[InlineData(3, 1)]
		[InlineData(1, 2)]
		[InlineData(1, 3)]
		[InlineData(3, 2)]
		[InlineData(2, 3)]
		[InlineData(3, 3)]
		public void CallSimpleResult(int scoreA, int scoreB)
		{
			_ = _testee.GetScore(scoreA, scoreB);

			A.CallTo(() => _scoreTranslatorFake.GetSimpleResult(scoreA, scoreB)).MustHaveHappened();
		}

		[Theory]
		[InlineData(4, 0, "A")]
		[InlineData(2, 4, "B")]
		[InlineData(7, 5, "A")]
		[InlineData(13, 15, "B")]
		public void CallGame(int scoreA, int scoreB, string winner)
		{
			_ = _testee.GetScore(scoreA, scoreB);

			A.CallTo(() => _scoreTranslatorFake.GetGame(winner)).MustHaveHappened();
		}
	}
}
