using Game;
using UnityEngine;

namespace Rules
{
    public sealed class GameTimerController : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        private GameTimer _gameTimer;

        private void Awake()
        {
            _gameTimer = GameTimer.Instance;
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