using System.Collections.Generic;

namespace Game
{
    public sealed class GameManagerContext
    {
        private readonly List<IGameListener> _listeners = new();

        public void AddListener(IGameListener listener) => _listeners.Add(listener);

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