using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool canOpenChest = false;
    public bool isOpen = false;

    public SpriteRenderer sprite;
    public Sprite spriteChestOpen;

    public GameObject keyE;

    // vérifie si le joueur est proche du coffre
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer") && !isOpen)
        {
            AbleToOpenChest(true);
        }
    }

    // vérifie si le joueur n'est plus proche du coffre
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer") && !isOpen)
        {
            AbleToOpenChest(false);
        }
    }

    private void Start()
    {
        // sécurité pour que la touche E ne soit pas affichée
        keyE.SetActive(false);
    }

    private void Update()
    {
        if (canOpenChest && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            OpenChest();
        }
    }

    // ouvre le coffre
    public void OpenChest()
    {
        isOpen = true;
        sprite.sprite = spriteChestOpen;
        keyE.SetActive(false);
        Reward();
    }

    // permet au joueur de pouvoir ouvrir ou non le coffre
    public void AbleToOpenChest(bool isAble)
    {
        canOpenChest = isAble;
        keyE.SetActive(isAble);
    }

    // choisis la récompense
    public void Reward()
    {
        int randomAmount = Random.Range(0, 10);
        PlayerCoins.instance.AddCoin(randomAmount);
        Debug.Log("+" + randomAmount + " gold");
    }
}
