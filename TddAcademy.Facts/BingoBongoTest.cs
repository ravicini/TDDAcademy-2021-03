using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
	public class BingoBongoTest
	{
		private readonly BingoBongoGame _bingoBongo;
		private readonly List<string> _expectedList;
		// todo: implement BingoBongo deriving from IBingoBongo test first

		// todo: modulo 3 == 0 return "bingo"
		// todo: modulo 5 == 0 returns "bongo"
		// todo: modulo 3 && modulo 5 return "bingo bongo"

		public BingoBongoTest()
		{
			_bingoBongo = new BingoBongoGame(120);

			_expectedList = new List<string>();

		}

		[Fact]
		public void CollectionWith120Items()
		{
			var testee = _bingoBongo.Play();

			testee.Should().HaveCount(120);
		}

		[Theory]
		[InlineData(1, "1")]
		[InlineData(3, "Bingo")]
		[InlineData(15, "BingoBongo")]
		[InlineData(37, "37")]
		[InlineData(60, "BingoBongo")]
		[InlineData(62, "62")]
		[InlineData(63, "BingoConga")]
		[InlineData(65, "Bongo")]
		[InlineData(75, "BingoBongo")]
		[InlineData(89, "89")]
		[InlineData(91, "Conga")]
		[InlineData(96, "Bingo")]
		[InlineData(100, "Bongo")]
		[InlineData(105, "BingoBongoConga")]
		public void TestRandomSampleContent(int i, string expected)
		{
			var testee = _bingoBongo.Play();

			testee.Should().HaveElementAt(i - 1, expected);
		}
	}
}
