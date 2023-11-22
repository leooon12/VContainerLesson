using App;
using Game;
using UnityEngine;

namespace Rules
{
    public sealed class SaveController : MonoBehaviour, IFinishGameListener
    {
        private GameTimer _gameTimer;

        private void Awake()
        {
            _gameTimer = GameTimer.Instance;
        }
        
        void IFinishGameListener.OnGameFinished()
        {
            SaveManager.SaveValue("Time", _gameTimer.CurrentTime);
        }
    }
}