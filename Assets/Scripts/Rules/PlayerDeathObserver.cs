using Game;

namespace Rules
{
    public sealed class PlayerDeathObserver : IStartGameListener, IFinishGameListener
    {
        private readonly IGameManager _gameManager;
        private readonly Player _player;

        public PlayerDeathObserver(IGameManager gameManager, Player player)
        {
            _gameManager = gameManager;
            _player = player;
        }

        void IStartGameListener.OnGameStarted()
        {
            _player.Destroyed += _gameManager.FinishGame;
        }

        void IFinishGameListener.OnGameFinished()
        {
            _player.Destroyed -= _gameManager.FinishGame;
        }
    }
}