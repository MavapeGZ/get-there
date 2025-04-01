using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameManager gameManager;
    public void PauseGame()
    {
        gameManager.Pause();
    }

    public void ResumeGame()
    {
        gameManager.Resume();
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
