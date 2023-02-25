using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public bool isGameOver = false;
    public GameObject gameOverMenu;

    public static GameOverMenu instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de GameOverMenu dans la scène");
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    // affiche le menu de Game Over
    public void GameOver()
    {
        if (PlayerHealth.instance.isDead)
        {
            isGameOver = true;
            gameOverMenu.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    // restart le jeu
    public void RestartGame()
    {
        isGameOver = false;
        gameOverMenu.SetActive(false);
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("CustomMenu");
    }

    // redirige vers le Main Menu
    public void MainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
    }

    // quitte le jeu
    public void Quit()
    {
        Application.Quit();
    }
}
