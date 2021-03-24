namespace TddAcademy
{
	public interface ITennisCounter
	{
		#region Properties

		int PointsPlayerA { get; }
		int PointsPlayerB { get; }

		#endregion

		void PlayerAScore();
		void PlayerBScore();
	}
}
