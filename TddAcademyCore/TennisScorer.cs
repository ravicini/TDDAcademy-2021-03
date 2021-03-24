namespace TddAcademy
{
	public class TennisScorer : ITennisScorer
	{
		#region Fields

		private readonly ITennisCounter counter;
		private readonly ITennisNaming naming;

		#endregion

		#region Properties

		public string Score => naming.GetNameByScore(counter.PointsPlayerA, counter.PointsPlayerB);

	#endregion

		public TennisScorer(ITennisCounter counter, ITennisNaming naming)
		{
			this.counter = counter;
			this.naming = naming;
		}

		#region Interface methods

		public void ScorePlayerA()
		{
			counter.PlayerAScore();
		}

		public void ScorePlayerB()
		{
			counter.PlayerBScore();
		}

		#endregion
	}
}
