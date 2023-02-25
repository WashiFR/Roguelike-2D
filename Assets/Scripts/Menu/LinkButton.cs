using UnityEngine;

public class LinkButton : MonoBehaviour
{
    public string link;

    public void OpenLink()
    {
        Application.OpenURL(link);
    }
}
