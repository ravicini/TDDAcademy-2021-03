namespace TddAcademy
{
    public class ScoreBuilder
    {
        public string BuildScoreString(IPlayer playerA, IPlayer playerB)
        {
            if (playerA.CurrentScore == playerB.CurrentScore && playerA.CurrentScore > 2)
            {
                return "deuce";
            }

            if (playerA.CurrentScore < 4 && playerB.CurrentScore < 4)
            {
                return $"{ConvertScoreToString(playerA.CurrentScore)}:{ConvertScoreToString(playerB.CurrentScore)}";
            }

            if (playerA.CurrentScore > playerB.CurrentScore + 1)
            {
                return "game A";
            }

            if (playerB.CurrentScore > playerA.CurrentScore + 1)
            {
                return "game B";
            }

            if (playerA.CurrentScore > playerB.CurrentScore)
            {
                return "advantage A";
            }

            if (playerB.CurrentScore > playerA.CurrentScore)
            {
                return "advantage B";
            }

            return "";
        }

        private static string ConvertScoreToString(int score)
        {
            return score switch
            {
                0 => "love",
                1 => "fifteen",
                2 => "thirty",
                3 => "forty",
                _ => ""
            };
        }
    }
}