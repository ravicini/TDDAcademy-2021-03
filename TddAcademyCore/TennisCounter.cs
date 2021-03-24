namespace TddAcademy
{
	public class TennisCounter : ITennisCounter
	{
		#region Properties

		public int PointsPlayerA { get; private set; }
		public int PointsPlayerB { get; private set; }

		#endregion

		#region Interface methods

		public void PlayerAScore()
		{
			PointsPlayerA++;
		}

		public void PlayerBScore()
		{
			PointsPlayerB++;
		}

		#endregion
	}
}
