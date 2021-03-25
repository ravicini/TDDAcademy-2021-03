using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
	public class ScoreTranslatorFact
	{
		#region Fields

		private readonly ScoreTranslator _testee;

		#endregion

		public ScoreTranslatorFact()
		{
			_testee = new ScoreTranslator();
		}

		[Theory]
		[InlineData(0, 0, "love:love")]
		[InlineData(1, 0, "fifteen:love")]
		[InlineData(2, 0, "thirty:love")]
		[InlineData(3, 0, "forty:love")]
		[InlineData(0, 1, "love:fifteen")]
		[InlineData(0, 2, "love:thirty")]
		[InlineData(0, 3, "love:forty")]
		[InlineData(1, 1, "fifteen:fifteen")]
		[InlineData(2, 1, "thirty:fifteen")]
		[InlineData(3, 1, "forty:fifteen")]
		[InlineData(1, 2, "fifteen:thirty")]
		[InlineData(1, 3, "fifteen:forty")]
		[InlineData(3, 2, "forty:thirty")]
		[InlineData(2, 3, "thirty:forty")]
		public void ReturnSimpleResult(int scoreA, int scoreB, string expectedScore)
		{
			var score = _testee.GetSimpleResult(scoreA, scoreB);

			score.Should().Be(expectedScore);
		}

		[Fact]
		public void ReturnDeuce()
		{
			_testee.Deuce.Should().Be("deuce");
		}

		[Theory]
		[InlineData("A", "advantage A")]
		[InlineData("B", "advantage B")]
		public void ReturnAdvantage(string player, string expectedScore)
		{
			var score = _testee.GetAdvantage(player);

			score.Should().Be(expectedScore);
		}

		[Theory]
		[InlineData("A", "game A")]
		[InlineData("B", "game B")]
		public void ReturnGame(string player, string expectedScore)
		{
			var score = _testee.GetGame(player);

			score.Should().Be(expectedScore);
		}
	}
}
