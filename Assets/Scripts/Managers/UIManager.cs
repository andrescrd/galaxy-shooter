using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Image liveImage;
    [SerializeField] private Sprite[] liveSprites;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);

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
        {
            gameOverText.gameObject.SetActive(true);
            StartCoroutine(GameOverFlicker());
        }
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