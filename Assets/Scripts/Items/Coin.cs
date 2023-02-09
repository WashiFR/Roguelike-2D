using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            Destroy(gameObject);
            AddCoin();
        }
    }

    // ajoute 1 pièce au joueur
    public void AddCoin()
    {
        Debug.Log("Pièce ramassée, +1 Gold");
    }
}
