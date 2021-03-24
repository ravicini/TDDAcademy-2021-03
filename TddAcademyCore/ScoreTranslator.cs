using System.Collections.Generic;

namespace TddAcademy
{
	public class ScoreTranslator
	{
		#region Fields

		private readonly Dictionary<int, string> _simpleScores = new()
			{
				{ 0, "love" },
				{ 1, "fifteen" },
				{ 2, "thirty" },
				{ 3, "forty" }
			};

		#endregion

		public string GetSimpleResult(int scoreA, int scoreB)
		{
			return $"{_simpleScores[scoreA]}:{_simpleScores[scoreB]}";
		}
	}
}
