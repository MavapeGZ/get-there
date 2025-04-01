using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    void Update()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
