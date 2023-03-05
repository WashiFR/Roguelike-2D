using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public Image image;
    public Sprite redButton;
    public Sprite orangeButton;

    public void RedButton()
    {
        image.sprite = redButton;
    }

    public void OrangeButton()
    {
        image.sprite = orangeButton;
    }
}
