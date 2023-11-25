using UnityEngine.SceneManagement;

namespace App
{
    public sealed class SceneController
    {
        public void RestartCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}