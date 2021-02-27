using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text restartText;
    [SerializeField] private Image liveImage;
    [SerializeField] private Sprite[] liveSprites;

    private GameManager _gameManager;
    
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();

        gameOverText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);

        if (scoreText)
            scoreText.text = $"Score: 0";
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateLives(int lives)
    {
        liveImage.sprite = liveSprites[lives];

        if (lives <= 0)
            GameOverSequence();
    }

    private void GameOverSequence()
    {
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlicker());
        
        _gameManager.GameOver();
    }

    private IEnumerator GameOverFlicker()
    {
        while (true)
        {
            gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}