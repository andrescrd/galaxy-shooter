using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"Score: 0";
    }
    
    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }
}