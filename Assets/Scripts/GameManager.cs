using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText; 
    public GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Game Over!";
        }
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true); 
        }
        if (player != null)
        {
            player.SetActive(true);
        }
        Time.timeScale = 0f;
    }
}