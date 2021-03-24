using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
	public class TennisCounterFact
	{
		#region Fields

		private readonly TennisCounter _testee;

		#endregion

		public TennisCounterFact()
		{
			_testee = new TennisCounter();
		}

		[Fact]
		public void TennisCounter_ShouldIncrementPlayerA()
		{
			var before = _testee.PointsPlayerA;
			_testee.PlayerAScore();

			var after1 = _testee.PointsPlayerA;
			_testee.PlayerAScore();

			_testee.PointsPlayerA.Should().Be(before + 1);
		}

		[Fact]
		public void TennisCounter_ShouldIncrementPlayerB()
		{
			var before = _testee.PointsPlayerB;
			_testee.PlayerBScore();

			_testee.PointsPlayerB.Should().Be(before + 1);
		}
	}
}
