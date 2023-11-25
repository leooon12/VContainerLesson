using Game;
using UI;

namespace Rules
{
    public sealed class GameOverScreenController : IInitializeGameListener, IFinishGameListener
    {
        private readonly GameTimer _gameTimer;
        private readonly GameOverScreen _gameOverScreen;

        GameOverScreenController(GameTimer gameTimer, GameOverScreen gameOverScreen)
        {
            _gameTimer = gameTimer;
            _gameOverScreen = gameOverScreen;
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