namespace Game
{
    public interface IGameListener
    {
        
    }

    public interface IInitializeGameListener : IGameListener
    {
        public void OnGameInitialized();
    }

    public interface IStartGameListener : IGameListener
    {
        public void OnGameStarted();
    }

    public interface IFinishGameListener : IGameListener
    {
        public void OnGameFinished();
    }
}