using Game;

namespace Rules
{
    public sealed class GameTimerController : IStartGameListener, IFinishGameListener
    {
        private readonly GameTimer _gameTimer;

        GameTimerController(GameTimer gameTimer)
        {
            _gameTimer = gameTimer;
        }
        
        void IStartGameListener.OnGameStarted()
        {
            _gameTimer.StartTimer();
        }

        void IFinishGameListener.OnGameFinished()
        {
            _gameTimer.StopTimer();
        }
    }
}