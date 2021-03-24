namespace TddAcademy.Facts
{
    public class Player : IPlayer
    {
        public int CurrentScore => _currentScore;

        private int _currentScore;

        public void Scored()
        {
            _currentScore++;
        }
    }
}