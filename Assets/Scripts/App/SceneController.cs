using UnityEngine.SceneManagement;

namespace App
{
    public static class SceneController
    {
        public static void RestartCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}