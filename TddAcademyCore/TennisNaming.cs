namespace TddAcademy
{
	public class TennisNaming : ITennisNaming
	{
		#region Interface methods

		public string GetNameByScore(int pointsPlayerA, int pointsPlayerB)
		{
			var diff = pointsPlayerA - pointsPlayerB;
			if ((diff > 1) && (pointsPlayerA > 3))
				return "game A";
			if((diff < -1) && (pointsPlayerB > 3))
				return "game B";

			if((diff == 0) && (pointsPlayerA > 2))
				return "deuce";

			if((diff == 1) && (pointsPlayerA > 3))
				return "advantage A";

			if((diff == -1) && (pointsPlayerB > 3))
				return "advantage B";

			var playerA = ConvertToName(pointsPlayerA);
			var playerB = ConvertToName(pointsPlayerB);
			return $"{playerA}:{playerB}";
		}

		#endregion

		private static string ConvertToName(int points)
		{
			switch(points)
			{
				case 0:
					return "love";
				case 1:
					return "fifteen";
				case 2:
					return "thirty";
				case 3:
					return "forty";
				default:
					return "";
			}
		}
	}
}
