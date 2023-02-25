using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public int currentClass;
    public Class[] classes;

    public SpriteRenderer sprite;

    public static PlayerClass instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerClass dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        CurrentClassUpdate();
    }

    public void CurrentClassUpdate()
    {
        for (int i = 0; i < classes.Length; i++)
        {
            if (i == currentClass)
            {
                classes[i].gameObject.SetActive(true);
            }
            else
            {
                classes[i].gameObject.SetActive(false);
            }
        }

        classes[currentClass].CurrentSexeUpdate();
        UpdateSprites();
    }

    public void ChangeCurrentClass(string className)
    {
        for (int i = 0; i < classes.Length; i++)
        {
            if (classes[i].className == className)
            {
                classes[i].gameObject.SetActive(true);
                currentClass = i;
            }
            else
            {
                classes[i].gameObject.SetActive(false);
            }
        }

        classes[currentClass].CurrentSexeUpdate();
        UpdateSprites();
    }

    public void UpdateSprites()
    {
        sprite = classes[currentClass].sprite;
        PlayerWeapon.instance.ChangeCurrentWeapon(classes[currentClass].weaponStartName);
        PlayerMovement.instance.UpdateMoveValues(classes[currentClass].speedValue, classes[currentClass].animator, classes[currentClass].sprite);
        PlayerHealth.instance.UpdateHealthValues(classes[currentClass].healthValue, classes[currentClass].healthValue, classes[currentClass].sprite);
    }
}
