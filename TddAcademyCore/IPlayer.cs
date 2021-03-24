namespace TddAcademy
{
    public interface IPlayer
    {
        public int CurrentScore { get; }

        public void Scored();
    }
}