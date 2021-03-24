namespace TddAcademy
{
    public class TennisScorer : ITennisScorer
	{
		private int _scoreA = 0;
		private int _scoreB = 0;
		private readonly ScoreAnalyzer _analyzer;

		public TennisScorer(ScoreAnalyzer analyzer)
		{
			_analyzer = analyzer;
		}

		public void ScorePlayerA()
		{
			_scoreA++;
		}

		public void ScorePlayerB()
		{
			_scoreB++;
		}

		public string Score
		{
			get
			{
				return _analyzer.GetScore(_scoreA, _scoreB);
			}
		}
    }
}
