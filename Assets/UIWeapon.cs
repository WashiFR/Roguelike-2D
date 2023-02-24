using UnityEngine;

public class UIWeapon : MonoBehaviour
{
    public ImageWeapon[] images;

    public static UIWeapon instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de UIWeapon dans la scène");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateImageCurrentWeapon();
    }

    public void UpdateImageCurrentWeapon()
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (PlayerWeapon.instance.weapons[PlayerWeapon.instance.currentWeapon].weaponName == images[i].weaponName)
            {
                images[i].gameObject.SetActive(true);
            }
            else
            {
                images[i].gameObject.SetActive(false);
            }
        }
    }
}
