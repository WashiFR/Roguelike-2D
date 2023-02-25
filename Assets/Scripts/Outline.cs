using UnityEngine;

public class Outline : MonoBehaviour
{
    public SpriteRenderer spriteR;
    public Sprite sprite;
    public int layer;

    void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>().sprite;

        if (gameObject.transform.parent.CompareTag("Chest"))
        {
            layer = -2;
        }
        else
        {
            layer = 9;
        }

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            spriteR = gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>();
            spriteR.sprite = sprite;
            gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = layer;
        }
    }

    private void Update()
    {
        if (gameObject.transform.parent.CompareTag("PlayerClassItem"))
        {
            sprite = GetComponentInParent<SpriteRenderer>().sprite;

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                spriteR = gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>();
                spriteR.sprite = sprite;
            }
        }
    }
}
