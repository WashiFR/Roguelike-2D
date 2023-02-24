using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public static PauseMenu instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PauseMenu dans la scène");
            return;
        }

        instance = this;
    }

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

    // redirige vers les paramètres
    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
}
