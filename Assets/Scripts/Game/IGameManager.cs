namespace Game
{
    public interface IGameManager
    {
        public void AddListener(IGameListener listener);

        public void InitializeGame();

        public void StartGame();

        public void FinishGame();
    }
}