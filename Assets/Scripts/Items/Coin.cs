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

    // ajoute 1 pi�ce au joueur
    public void AddCoin()
    {
        Debug.Log("Pi�ce ramass�e, +1 Gold");
    }
}
