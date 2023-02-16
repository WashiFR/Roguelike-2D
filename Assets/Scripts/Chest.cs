using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public bool canOpenChest = false;
    public bool isOpen = false;

    public SpriteRenderer sprite;
    public Sprite spriteChestOpen;

    public GameObject keyE;

    public Text textReward;
    public Animator animatorText;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    // v�rifie si le joueur est proche du coffre
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer") && !isOpen)
        {
            AbleToOpenChest(true);
        }
    }

    // v�rifie si le joueur n'est plus proche du coffre
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer") && !isOpen)
        {
            AbleToOpenChest(false);
        }
    }

    private void Start()
    {
        // s�curit� pour que la touche E ne soit pas affich�e
        keyE.SetActive(false);
    }

    private void Update()
    {
        OpenChest();
    }

    // ouvre le coffre
    public void OpenChest()
    {
        if (canOpenChest && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            isOpen = true;
            sprite.sprite = spriteChestOpen;
            keyE.SetActive(false);
            Reward();
        }
    }

    // permet au joueur de pouvoir ouvrir ou non le coffre
    public void AbleToOpenChest(bool isAble)
    {
        canOpenChest = isAble;
        keyE.SetActive(isAble);
    }

    // choisis la r�compense
    public void Reward()
    {
        int randomAmount = Random.Range(0, 10);
        PlayerCoins.instance.AddCoin(randomAmount);
        textReward.text = "+ " + randomAmount.ToString() + " gold";
        StartCoroutine(ShowTextReward());
    }

    // affiche la r�compense pendant un certains temps
    public IEnumerator ShowTextReward()
    {
        animatorText.SetTrigger("UpText");
        yield return new WaitForSeconds(2);
        textReward.text = "";
    }
}
