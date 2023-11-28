using App;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public sealed class GameOverScreen : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI messageText;

        [SerializeField]
        private Button restartButton;

        private SceneController _sceneController;
        
        [Inject]
        private void Construct(SceneController sceneController)
        {
            _sceneController = sceneController;
        }
        
        private void OnEnable()
        {
            restartButton.onClick.AddListener(_sceneController.RestartCurrentScene);
        }

        private void OnDisable()
        {
            restartButton.onClick.RemoveListener(_sceneController.RestartCurrentScene);
        }

        public void Show(string text)
        {
            gameObject.SetActive(true);

            messageText.text = text;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}