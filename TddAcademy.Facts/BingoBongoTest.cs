using System.Linq;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
	public class BingoBongoTest
	{
		#region Fields

		private readonly BingoBongo _testee;

		#endregion

		public BingoBongoTest()
		{
			_testee = new BingoBongo();
		}

		[Fact]
		public void FirstShouldReturn1()
		{
			var result = _testee.Play();

			result.First().Should().Be("1");
		}

		[Fact]
		public void LastShouldReturnBingoBongo()
		{
			var result = _testee.Play();

			result.Last().Should().Be("BingoBongo");
		}

		[Fact]
		public void MultiplyOf3ReturnsBingo()
		{
			var result = _testee.Play();

			result[2].Should().Be("Bingo");
			result[5].Should().Be("Bingo");
			result[8].Should().Be("Bingo");
			result[32].Should().Be("Bingo");
			result[98].Should().Be("Bingo");
		}

		[Fact]
		public void MultiplyOf5ReturnsBongo()
		{
			var result = _testee.Play();

			result[4].Should().Be("Bongo");
			result[9].Should().Be("Bongo");
			result[19].Should().Be("Bongo");
			result[54].Should().Be("Bongo");
			result[99].Should().Be("Bongo");
		}

		[Fact]
		public void MultiplyOf7ReturnsConga()
		{
			var result = _testee.Play();

			result[6].Should().Be("Conga");
			result[13].Should().Be("Conga");
		}

		[Fact]
		public void MultiplyOf3And5ReturnsBingoBongo()
		{
			var result = _testee.Play();

			result[14].Should().Be("BingoBongo");
			result[29].Should().Be("BingoBongo");
			result[44].Should().Be("BingoBongo");
			result[89].Should().Be("BingoBongo");
		}

		[Fact]
		public void MultiplyOf3And7ReturnsBingoConga()
		{
			var result = _testee.Play();

			result[20].Should().Be("BingoConga");
			result[41].Should().Be("BingoConga");
		}

		[Fact]
		public void MultiplyOf5And7ReturnsBongoConga()
		{
			var result = _testee.Play();

			result[34].Should().Be("BongoConga");
			result[69].Should().Be("BongoConga");
		}

		[Fact]
		public void MultiplyOf3And5And7ReturnsBingoBongoConga()
		{
			var result = _testee.Play();

			result[104].Should().Be("BingoBongoConga");
		}
	}
}
