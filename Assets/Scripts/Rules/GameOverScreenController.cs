using Game;
using UI;
using UnityEngine;

namespace Rules
{
    public sealed class GameOverScreenController : MonoBehaviour, IInitializeGameListener, IFinishGameListener
    {
        [SerializeField]
        private GameOverScreen gameOverScreen;
        
        private GameTimer _gameTimer;

        private void Awake()
        {
            _gameTimer = GameTimer.Instance;
        }
        
        void IInitializeGameListener.OnGameInitialized()
        {
            gameOverScreen.Hide();
        }

        void IFinishGameListener.OnGameFinished()
        {
            gameOverScreen.Show($"Game over!\nYour time: {_gameTimer.CurrentTime:F1}");
        }
    }
}