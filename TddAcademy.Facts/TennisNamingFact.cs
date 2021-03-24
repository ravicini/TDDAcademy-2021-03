using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
	public class TennisNamingFact
	{
		#region Fields

		private readonly TennisNaming _testee;

		#endregion

		public TennisNamingFact()
		{
			_testee = new TennisNaming();
		}

		[Theory]
		[InlineData(0, 0, "love:love")]
		[InlineData(3, 0, "forty:love")]
		[InlineData(2, 2, "thirty:thirty")]
		public void TennisNaming_ShouldNameCorrectly(int pointsPlayerA, int pointsPlayerB, string expectedResult)
		{
			var result = _testee.GetNameByScore(pointsPlayerA, pointsPlayerB);

			result.Should().Be(expectedResult);
		}

		[Theory]
		[InlineData(4, 0, "game A")]
		[InlineData(0, 4, "game B")]
		[InlineData(4, 2, "game A")]
		[InlineData(8, 6, "game A")]
		[InlineData(7, 9, "game B")]
		public void TennisNaming_ShouldDisplayGameFinished(int pointsPlayerA, int pointsPlayerB, string expectedResult)
		{
			var result = _testee.GetNameByScore(pointsPlayerA, pointsPlayerB);

			result.Should().Be(expectedResult);
		}

		[Theory]
		[InlineData(3, 3, "deuce")]
		[InlineData(7, 7, "deuce")]
		public void TennisNaming_ShouldDisplayDeuce(int pointsPlayerA, int pointsPlayerB, string expectedResult)
		{
			var result = _testee.GetNameByScore(pointsPlayerA, pointsPlayerB);

			result.Should().Be(expectedResult);
		}

		[Theory]
		[InlineData(4, 3, "advantage A")]
		[InlineData(7, 8, "advantage B")]
		public void TennisNaming_ShouldDisplayAdvantage(int pointsPlayerA, int pointsPlayerB, string expectedResult)
		{
			var result = _testee.GetNameByScore(pointsPlayerA, pointsPlayerB);

			result.Should().Be(expectedResult);
		}
	}
}
