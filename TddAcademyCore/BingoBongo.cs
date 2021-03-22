using System.Collections.Generic;
using System.Collections.Immutable;

namespace TddAcademy.Facts
{
	public class BingoBongo : IBingoBongo
	{
		#region Constants

		private const int c_counterMin = 1;
		private const int c_counterMax = 120;

		#endregion

		#region Interface methods

		public IImmutableList<string> Play()
		{
			var list = new List<string>();
			for(int counter = c_counterMin; counter <= c_counterMax; counter++)
			{
				if(!((counter % 3 == 0) || (counter % 5 == 0) || (counter % 7 == 0)))
				{
					list.Add(counter.ToString());
					continue;
				}

				var entry = "";
				if(counter % 3 == 0)
					entry += "Bingo";
				if(counter % 5 == 0)
					entry += "Bongo";
				if(counter % 7 == 0)
					entry += "Conga";

				list.Add(entry);
			}
			return list.ToImmutableArray();
		}

		#endregion
	}
}
