using System.Collections.Generic;
using System.Collections.Immutable;

namespace TddAcademy
{
	public interface IBingoBongo
	{
		IImmutableList<string> Play();
	}

	public class BingoBongo : IBingoBongo
	{
		#region Fields

		private readonly List<string> _items;

		#endregion

		public BingoBongo()
		{
			_items = new List<string>();
		}

		#region Interface methods

		public IImmutableList<string> Play()
		{
			for(int i = 1; i <= 100; i++)
			{
				if((i % 3 == 0) && (i % 5 == 0))
					_items.Add("BingoBongo");
				else if(i % 3 == 0)
					_items.Add("Bingo");
				else if(i % 5 == 0)
					_items.Add("Bongo");
				else
					_items.Add(i.ToString());
			}
			return _items.ToImmutableArray();
		}

		#endregion
	}
}
