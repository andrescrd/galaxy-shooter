using UnityEngine;
using UnityEngine.SceneManagement;

namespace Views
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadNewGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}