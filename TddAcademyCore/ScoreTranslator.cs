using System.Collections.Generic;

namespace TddAcademy
{
	public class ScoreTranslator : IScoreTranslator
	{
		#region Constants

		private const string c_Tie = "deuce";

		#endregion

		#region Fields

		private readonly Dictionary<int, string> _simpleScores = new()
			{
				{ 0, "love" },
				{ 1, "fifteen" },
				{ 2, "thirty" },
				{ 3, "forty" }
			};

		#endregion

		#region Properties

		public string Tie => c_Tie;

		#endregion

		#region Interface methods

		public string GetSimpleResult(int scoreA, int scoreB)
		{
			return $"{_simpleScores[scoreA]}:{_simpleScores[scoreB]}";
		}

		public string GetAdvantage(string player) => $"advantage {player}";

		public string GetGame(string player) => $"game {player}";

		#endregion
	}
}
