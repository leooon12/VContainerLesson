using Game;
using UnityEngine;

namespace UI
{
    public sealed class PlayerHealthAdapter : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        private TextWidget textWidget;

        private Player _player;

        private void Awake()
        {
            _player = Player.Instance;
        }

        void IStartGameListener.OnGameStarted()
        {
            _player.HealthChanged += SetHealth;
            
            SetHealth(_player.Health);
        }

        void IFinishGameListener.OnGameFinished()
        {
            _player.HealthChanged -= SetHealth;
        }

        private void SetHealth(int health)
        {
            textWidget.Text = health.ToString();
        }
    }
}