using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Resolution[] resolutions;

    private void Start()
    {
        // r�cup�re toutes les r�solutions possibles de l'utilisateurs (sans doublons)
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            // permet de trouver la + grande r�solution
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        // permet de mettre la + grande r�solution
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // permet de changer la r�solution du jeu
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    // permet de mettre le jeu en plein �cran ou non
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    // permet de r�gler le volume du jeu
    public void SetVolume(float volume)
    {
        // TODO
    }

    // permet de quitter le menu de param�tre
    public void ExitMenu()
    {
        gameObject.SetActive(false);
    }
}
