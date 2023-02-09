using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    public int amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            Destroy(gameObject);
            Heal(amount);
        }
    }

    // soigne le joueur � la hauteur du montant d�finis
    public void Heal(int amount)
    {
        Debug.Log("Potion de soins utilis�e, +" + amount + " PV.");
    }
}
