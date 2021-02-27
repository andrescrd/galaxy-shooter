using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool _isGameOver;

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R) && _isGameOver)
                SceneManager.LoadScene(sceneBuildIndex: 1);
        }

        public void GameOver()
        {
            _isGameOver = true;
        }
    }
}