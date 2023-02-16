using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextButtonMenu : MonoBehaviour
{
    public GameObject leftArrow;
    public GameObject rightArrow;

    // affiche la flèche
    public void ShowArrow()
    {
        leftArrow.SetActive(true);
        rightArrow.SetActive(true);
    }

    // n'affiche pas la flèche
    public void HideArrow()
    {
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
    }
}
