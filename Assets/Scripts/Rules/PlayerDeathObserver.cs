using Game;
using UnityEngine;

namespace Rules
{
    public sealed class PlayerDeathObserver : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        private GameManager _gameManager;
        private Player _player;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
            _player = Player.Instance;
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