using System.Collections.Generic;
using VContainer;

namespace Game
{
    public sealed class GameManagerContext
    {
        [Inject]
        private readonly IEnumerable<IGameListener> _listeners;

        public void OnGameInitialized()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IInitializeGameListener initializeGameListener)
                {
                    initializeGameListener.OnGameInitialized();
                }
            }
        }

        public void OnGameStarted()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IStartGameListener startGameListener)
                {
                    startGameListener.OnGameStarted();
                }
            }
        }

        public void OnGameFinished()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IFinishGameListener finishGameListener)
                {
                    finishGameListener.OnGameFinished();
                }
            }
        }
    }
}