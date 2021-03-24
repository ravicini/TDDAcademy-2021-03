namespace TddAcademy.Specs
{
    public class TennisScorer : ITennisScorer
    {
        private readonly IPlayer _playerA;
        private readonly IPlayer _playerB;
        private readonly ScoreBuilder _scoreBuilder;

        public TennisScorer(IPlayer playerA, IPlayer playerB, ScoreBuilder scoreBuilder)
        {
            _playerA = playerA;
            _playerB = playerB;
            _scoreBuilder = scoreBuilder;
        }

        public void ScorePlayerA()
        {
            _playerA.Scored();
        }

        public void ScorePlayerB()
        {
            _playerB.Scored();
        }

        public string Score => _scoreBuilder.BuildScoreString(_playerA, _playerB);
    }
}