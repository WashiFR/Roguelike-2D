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

    // soigne le joueur à la hauteur du montant définis
    public void Heal(int amount)
    {
        Debug.Log("Potion de soins utilisée, +" + amount + " PV.");
    }
}
