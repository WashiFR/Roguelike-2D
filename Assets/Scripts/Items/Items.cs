using UnityEngine;
using UnityEngine.UI;

public abstract class Items : MonoBehaviour
{
    public bool canTakeItem;

    public int price;
    public SpriteRenderer sprite;
    public Text textPrice;
    public GameObject keyE;

    public GameObject outline;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            if (price == 0)
            {
                canTakeItem = true;

                if (gameObject.CompareTag("Item"))
                {
                    UseItem();
                }
                else if (gameObject.CompareTag("ItemWeapon"))
                {
                    outline.gameObject.SetActive(true);
                    sprite.sortingOrder = 10;
                    keyE.SetActive(true);
                }
            }
            else if (price > 0)
            {
                outline.gameObject.SetActive(true);
                sprite.sortingOrder = 10;
                keyE.SetActive(true);
                textPrice.gameObject.SetActive(true);

                if (price <= PlayerCoins.instance.coinsCount)
                {
                    canTakeItem = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            outline.gameObject.SetActive(false);
            sprite.sortingOrder = -1;
            canTakeItem = false;
            keyE.SetActive(false);
            textPrice.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        if (price > 0)
        {
            textPrice.gameObject.SetActive(false);
            textPrice.text = price.ToString();
        }
    }

    private void Update()
    {
        if (canTakeItem && Input.GetKeyDown(KeyCode.E))
        {
            UseItem();
        }
    }

    // utilise l'objet
    public abstract void UseItem();
}
