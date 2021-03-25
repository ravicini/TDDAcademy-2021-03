using System;

namespace TddAcademy
{
	public class ScoreAnalyzer
	{
		#region Fields

		private readonly IScoreTranslator _translator;

		#endregion

		public ScoreAnalyzer(IScoreTranslator translator)
		{
			_translator = translator;
		}

		public string GetScore(int scoreA, int scoreB)
		{
			if((scoreA > 3) || (scoreB > 3))
			{
				int scoreDiff = Math.Abs(scoreA - scoreB);
				if(scoreDiff >= 2)
				{
					if(scoreA > scoreB)
						return _translator.GetGame("A");
					else
						return _translator.GetGame("B");
				}
				else if(scoreDiff == 1)
				{
					if(scoreA > scoreB)
						return _translator.GetAdvantage("A");
					else
						return _translator.GetAdvantage("B");
				}
				else
					return _translator.Deuce;
			}
			else
				return _translator.GetSimpleResult(scoreA, scoreB);
		}
	}
}
