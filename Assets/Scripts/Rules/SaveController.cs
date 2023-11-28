using App;
using Game;

namespace Rules
{
    public sealed class SaveController : IFinishGameListener
    {
        private readonly GameTimer _gameTimer;
        private readonly SaveManager _saveManager;

        public SaveController(GameTimer gameTimer, SaveManager saveManager)
        {
            _gameTimer = gameTimer;
            _saveManager = saveManager;
        }
        
        void IFinishGameListener.OnGameFinished()
        {
            _saveManager.SaveValue("Time", _gameTimer.CurrentTime);
        }
    }
}