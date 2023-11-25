using Game;
using UnityEngine;
using VContainer;

namespace UI
{
    public sealed class GameTimerAdapter : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        private TextWidget textWidget;
        
        private GameTimer _gameTimer;

        [Inject]
        private void Construct(GameTimer gameTimer)
        {
            _gameTimer = gameTimer;
        }

        void IStartGameListener.OnGameStarted()
        {
            _gameTimer.Ticked += SetTime;
            
            SetTime(_gameTimer.CurrentTime);
        }

        void IFinishGameListener.OnGameFinished()
        {
            _gameTimer.Ticked -= SetTime;
        }

        private void SetTime(float time)
        {
            textWidget.Text = time.ToString("F1");
        }
    }
}