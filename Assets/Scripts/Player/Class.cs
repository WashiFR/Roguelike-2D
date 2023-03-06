using UnityEngine;

public class Class : MonoBehaviour
{
    public string className;

    public int currentSexe;
    public PlayerSexe[] sexes;

    public Animator animator;

    public float healthValue;
    public float armorValue;
    public float speedValue;
    public string weaponStartName;

    public SpriteRenderer sprite;

    public void CurrentSexeUpdate()
    {
        for (int i = 0; i < sexes.Length; i++)
        {
            if (i == currentSexe)
            {
                sexes[i].gameObject.SetActive(true);
            }
            else
            {
                sexes[i].gameObject.SetActive(false);
            }
        }

        animator = sexes[currentSexe].animator;
        sprite = sexes[currentSexe].sprite;
        PlayerClass.instance.UpdateSprites();
    }

    public void ChangeSexeClass(string sexe)
    {
        for (int i = 0; i < sexes.Length; i++)
        {
            if (sexes[i].sexe == sexe)
            {
                sexes[i].gameObject.SetActive(true);
                currentSexe = i;
            }
            else
            {
                sexes[i].gameObject.SetActive(false);
            }
        }

        animator = sexes[currentSexe].animator;
        sprite = sexes[currentSexe].sprite;
        PlayerClass.instance.UpdateSprites();
    }
}
