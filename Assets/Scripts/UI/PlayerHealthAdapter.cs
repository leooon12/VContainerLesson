using Game;
using UnityEngine;
using VContainer;

namespace UI
{
    public sealed class PlayerHealthAdapter : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        private TextWidget textWidget;

        private Player _player;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
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