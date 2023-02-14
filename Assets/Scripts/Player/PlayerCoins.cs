using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoins : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public static PlayerCoins instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerCoins dans la scène");
            return;
        }

        instance = this;
    }

    // ajoute le montant au total de nombre de pièce
    public void AddCoin(int amount)
    {
        coinsCount += amount;
        UpdateCoinsCount();
    }

    // retire le montant du prix au total de nombre de pièce
    public void Pay(int price)
    {
        coinsCount -= price;
        UpdateCoinsCount();
    }

    // met à jour l'affichage du nombre de pièce
    public void UpdateCoinsCount()
    {
        coinsCountText.text = coinsCount.ToString();
    }
}
