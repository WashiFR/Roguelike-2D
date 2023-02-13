using System.Collections;
using System.Collections.Generic;
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
        if (PlayerHealth.instance.isDead)
        {
            GameOver();

            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    // affiche le menu de Game Over
    public void GameOver()
    {
        isGameOver = true;
        gameOverMenu.SetActive(true);
    }

    // restart le jeu
    public void RestartGame()
    {
        isGameOver = false;
        gameOverMenu.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }
}
