using Game;
using UI;

namespace Rules
{
    public sealed class GameOverScreenController : IInitializeGameListener, IFinishGameListener
    {
        private readonly GameOverScreen _gameOverScreen;
        private readonly GameTimer _gameTimer;

        public GameOverScreenController(GameOverScreen gameOverScreen, GameTimer gameTimer)
        {
            _gameOverScreen = gameOverScreen;
            _gameTimer = gameTimer;
        }
        
        void IInitializeGameListener.OnGameInitialized()
        {
            _gameOverScreen.Hide();
        }

        void IFinishGameListener.OnGameFinished()
        {
            _gameOverScreen.Show($"Game over!\nYour time: {_gameTimer.CurrentTime:F1}");
        }
    }
}