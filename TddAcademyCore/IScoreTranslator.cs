namespace TddAcademy
{
	public interface IScoreTranslator
	{
		#region Properties

		public string Tie { get; }

		#endregion

		string GetSimpleResult(int scoreA, int scoreB);

		string GetAdvantage(string player);

		string GetGame(string player);
	}
}
