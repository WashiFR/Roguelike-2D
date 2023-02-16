using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOverMenu.instance.isGameOver)
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    // met le jeu en pause
    public void PauseGame()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    // reprend le jeu
    public void ResumeGame()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // redirige vers le Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    // redirige vers les param�tres
    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
}
