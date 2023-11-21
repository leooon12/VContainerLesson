using App;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class GameOverScreen : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI messageText;

        [SerializeField]
        private Button restartButton;

        private void OnEnable()
        {
            restartButton.onClick.AddListener(SceneController.RestartCurrentScene);
        }

        private void OnDisable()
        {
            restartButton.onClick.RemoveListener(SceneController.RestartCurrentScene);
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