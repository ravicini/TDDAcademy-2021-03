using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace TddAcademy.Facts
{
	public class BingoBongoGame : IBingoBongo
	{
		#region Constants

		private const string c_bingo = "Bingo";
		private const string c_bongo = "Bongo";
		private const string c_conga = "Conga";

		#endregion

		#region Fields

		private readonly List<string> _list;

		#endregion

		public BingoBongoGame(int count)
		{
			_list = new List<string>();
			for(int i = 1; i <= count; i++)
			{
				string temp = "";
				if(i % 3 == 0)
					temp += c_bingo;
				if(i % 5 == 0)
					temp += c_bongo;
				if(i % 7 == 0)
					temp += c_conga;
				if(String.IsNullOrEmpty(temp))
					_list.Add(i.ToString());
				else
					_list.Add(temp);
			}
		}

		#region Interface methods

		public IImmutableList<string> Play()
		{
			return _list.ToImmutableList();
		}

		#endregion
	}
}
