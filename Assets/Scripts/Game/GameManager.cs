using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Assertions;
using Utility;
using VContainer;

namespace Game
{
    [DefaultExecutionOrder(-100)]
    public sealed class GameManager : MonoBehaviour, IGameManager
    {
        [ShowInInspector, ReadOnly]
        public GameState CurrentState { get; private set; } = GameState.Idle;

        [SerializeField]
        private bool autoRun = true;

        private readonly GameManagerContext _context = new();

        private IObjectResolver _objectResolver;

        [Inject]
        private void Construct(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        private void Awake()
        {
            _objectResolver.Inject(_context);
        }
        
        private void Start()
        {
            if (autoRun)
            {
                InitializeGame();
                StartGame();
            }
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
