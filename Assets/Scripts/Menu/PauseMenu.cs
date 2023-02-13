using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOverMenu.instance.isGameOver)
        {
            if (!isGamePaused)
            {
                isGamePaused = true;
                PauseGame();
            }
            else
            {
                isGamePaused = false;
                ResumeGame();
            }
        }
    }

    // met le jeu en pause
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    // reprend le jeu
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
