using UnityEngine;

namespace Game
{
    public sealed class GameListenersInstaller : MonoBehaviour
    {
        private void Awake()
        {
            var gameManager = GameManager.Instance;

            foreach (var listener in GetComponentsInChildren<IGameListener>())
            {
                gameManager.AddListener(listener);
            }
        }
    }
}