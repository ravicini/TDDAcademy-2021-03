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
			if((scoreA < 4) && (scoreB < 4))
				return _translator.GetSimpleResult(scoreA, scoreB);
			else
				return "";
		}
	}
}
