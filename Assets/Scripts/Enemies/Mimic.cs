using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{
    public float damage;

    public bool canOpenChest = false;
    public bool isOpen = false;

    public GameObject keyE;
    public GameObject mimicEnemy;

    // vérifie si le joueur est proche du mimic
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer") && !isOpen)
        {
            AbleToOpenChest(true);
        }
    }

    // vérifie si le joueur n'est plus proche du mimic
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
        OpenChest();
    }

    // ouvre le coffre
    public void OpenChest()
    {
        if (canOpenChest && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            isOpen = true;
            keyE.SetActive(false);
            PlayerHealth.instance.TakeDamage(damage);
            Instantiate(mimicEnemy, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    // permet au joueur de pouvoir ouvrir ou non le mimic
    public void AbleToOpenChest(bool isAble)
    {
        canOpenChest = isAble;
        keyE.SetActive(isAble);
    }
}
