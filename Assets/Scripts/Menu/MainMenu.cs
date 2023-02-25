using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    public string levelToLoad;

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
