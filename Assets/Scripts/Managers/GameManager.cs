using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinsText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI finalText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    [SerializeField]
    private Button button;

    private float time = 60.99f;
    private int coins = 0;
    private int score = 0;

    private void Start()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString(); // First HighScore = 0
    }

    private void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            timeText.text = "" + (int)time; // Cast to see only the seconds
        }
        else
        {
            GameOver();
        }
    }

    public void GivePoints()
    {
        coins++;

        if (coins < 10)
        {
            coinsText.text = "x0" + coins;
        }
        else
        {
            coinsText.text = "x" + coins;
        }

        if (coins >= 15)
        {
            WinGame();
        }

        if (time <= 0f)
        {
            GameOver();
        }
    }

    public void WinGame()
    {
        if (coins >= 15)
        {
            score = (int)(coins * time);
        }

        finalText.gameObject.SetActive(true);
        finalText.text = "YOU WIN!";
        scoreText.gameObject.SetActive(true);

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            scoreText.text = "New HighScore: " + score;
            highScoreText.text = "HighScore: " + score; // Update high score text immediately
        }
        else
        {
            scoreText.text = "Your Score: " + score;
        }

        Pause();
        button.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        score = 0; 

        finalText.gameObject.SetActive(true);
        finalText.text = "YOU LOSE!";
        scoreText.gameObject.SetActive(true);
        scoreText.text = "Your Score: " + score;

        Pause();
        button.gameObject.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
