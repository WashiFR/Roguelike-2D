using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPotion : MonoBehaviour
{
    public float amount;

    public bool canTakeItem;

    public int price;
    public SpriteRenderer sprite;
    public Text textPrice;
    public GameObject keyE;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            if (price == 0)
            {
                canTakeItem = true;
                UseItem();
            }
            else if (price > 0)
            {
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
        if (collision.CompareTag("FootPlayer") && price > 0)
        {
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
        if (canTakeItem && Input.GetKeyDown(KeyCode.E) && price > 0)
        {
            UseItem();
            PlayerCoins.instance.Pay(price);
        }
    }

    public void UseItem()
    {
        AudioManager.instance.PlayClipAt(soundEffect, transform.position);
        PlayerMovement.instance.MoreSpeedValue(amount);
        Destroy(gameObject);
    }
}
