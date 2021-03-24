using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
	// todo: methode deuce
	// todo: methode advantage (A/B)
	// todo: methode game (A/B)
	// todo: 

	public class ScoreTranslatorFact
	{
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
		[InlineData(3, 3, "forty:forty")]
		public void ReturnSimpleResult(int scoreA, int scoreB, string expectedScore)
		{
			var testee = new ScoreTranslator();

			var score = testee.GetSimpleResult(scoreA, scoreB);

			score.Should().Be(expectedScore);
		}
	}
}
