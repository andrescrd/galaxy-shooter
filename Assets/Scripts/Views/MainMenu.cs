using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadNewGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}