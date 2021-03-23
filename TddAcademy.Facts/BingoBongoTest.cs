using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
	public class BingoBongoTest
	{
		[Fact]
		public void BingoBongo_ShouldNotBeBull()
		{
			IBingoBongo testee = new BingoBongo();

			var result = testee.Play();

			result.Should().NotBeNull();
		}

		[Fact]
		public void BingoBongo_ShouldReturn100Items()
		{
			IBingoBongo testee = new BingoBongo();

			var result = testee.Play();

			result.Should().HaveCount(100);
		}

		[Fact]
		public void BingoBongo_ShouldReturnFirstNumber()
		{
			IBingoBongo testee = new BingoBongo();

			var result = testee.Play();

			result.Should().StartWith("1");
		}

		[Theory]
		[InlineData(0, "1")]
		[InlineData(42, "43")]
		[InlineData(85, "86")]
		public void BingoBongo_ShouldReturnNumbers(int index, string expected)
		{
			IBingoBongo testee = new BingoBongo();

			var result = testee.Play();

			result.Should().HaveElementAt(index, expected);
		}

		[Theory]
		[InlineData(2)]
		[InlineData(32)]
		[InlineData(80)]
		public void BingoBongo_ShoudReturnBingo(int index)
		{
			IBingoBongo testee = new BingoBongo();

			var result = testee.Play();

			result.Should().HaveElementAt(index, "Bingo");
		}

		[Theory]
		[InlineData(4)]
		[InlineData(24)]
		[InlineData(64)]
		public void BingoBongo_ShoudReturnBongo(int index)
		{
			IBingoBongo testee = new BingoBongo();

			var result = testee.Play();

			result.Should().HaveElementAt(index, "Bongo");
		}

		[Theory]
		[InlineData(14)]
		[InlineData(29)]
		[InlineData(74)]
		public void BingoBongo_ShoudReturnBingoBongo(int index)
		{
			IBingoBongo testee = new BingoBongo();

			var result = testee.Play();

			result.Should().HaveElementAt(index, "BingoBongo");
		}
	}
}
