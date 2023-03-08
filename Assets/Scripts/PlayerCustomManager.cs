using UnityEngine;

public class PlayerCustomManager : MonoBehaviour
{
    public int currentClassUsed;
    public PlayerClassItem[] classes;

    public static PlayerCustomManager instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerCustomManager dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        UpdateClassItem();
    }

    public void UpdateClassItem()
    {
        for (int i = 0; i < classes.Length; i++)
        {
            if (classes[i].isUsed)
            {
                classes[i].gameObject.SetActive(false);
                currentClassUsed = i;
            }
            else
            {
                classes[i].gameObject.SetActive(true);
            }
        }
    }

    public void ChangeCurrentClassUsed()
    {
        classes[currentClassUsed].isUsed = false;
    }
}
