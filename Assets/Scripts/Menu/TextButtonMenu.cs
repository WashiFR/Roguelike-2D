using UnityEngine;

public class TextButtonMenu : MonoBehaviour
{
    public GameObject leftArrow;
    public GameObject rightArrow;

    // affiche la fl�che
    public void ShowArrow()
    {
        leftArrow.SetActive(true);
        rightArrow.SetActive(true);
    }

    // n'affiche pas la fl�che
    public void HideArrow()
    {
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
    }
}
