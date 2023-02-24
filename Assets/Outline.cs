using UnityEngine;

public class Outline : MonoBehaviour
{
    public SpriteRenderer spriteR;
    public Sprite sprite;
    public int layer;

    void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>().sprite;

        if (gameObject.transform.parent.CompareTag("Item") || gameObject.transform.parent.CompareTag("ItemWeapon"))
        {
            layer = 9;
        }
        else if (gameObject.transform.parent.CompareTag("Chest"))
        {
            layer = -2;
        }

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            spriteR = gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>();
            spriteR.sprite = sprite;
            gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = layer;
        }
    }
}
