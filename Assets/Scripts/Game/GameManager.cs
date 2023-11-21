using Sirenix.OdinInspector;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Assertions;
using Utility;

namespace Game
{
    [DefaultExecutionOrder(-100)]
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [ShowInInspector, ReadOnly]
        public GameState CurrentState { get; private set; } = GameState.Idle;

        [SerializeField]
        private bool autoRun = true;

        private readonly GameManagerContext _context = new();
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        
        private void Start()
        {
            if (autoRun)
            {
                InitializeGame();
                StartGame();
            }
        }

        public void AddListener(IGameListener listener)
        {
            _context.AddListener(listener);
        }
        
        [Button]
        public void InitializeGame()
        {
            Assert.AreEqual(GameState.Idle, CurrentState, Errors.UnexpectedGameState);

            CurrentState = GameState.Initialized;
            _context.OnGameInitialized();
        }

        [Button]
        public void StartGame()
        {
            Assert.AreEqual(GameState.Initialized, CurrentState, Errors.UnexpectedGameState);

            CurrentState = GameState.Running;
            _context.OnGameStarted();
        }

        [Button]
        public void FinishGame()
        {
            Assert.AreEqual(GameState.Running, CurrentState, Errors.UnexpectedGameState);

            CurrentState = GameState.Finished;
            _context.OnGameFinished();
        }
    }
}
