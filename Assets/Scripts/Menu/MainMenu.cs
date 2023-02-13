using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsMenu;

    // bouton pour lancer le jeu
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    // bouton pour aller dans les paramètres
    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    // bouton pour quitter le jeu
    public void QuitGame()
    {
        Application.Quit();
    }
}
