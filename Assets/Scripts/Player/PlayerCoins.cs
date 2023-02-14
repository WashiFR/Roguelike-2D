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
            Debug.LogWarning("Plus d'une instance de PlayerCoins dans la sc�ne");
            return;
        }

        instance = this;
    }

    // ajoute le montant au total de nombre de pi�ce
    public void AddCoin(int amount)
    {
        coinsCount += amount;
        UpdateCoinsCount();
    }

    // retire le montant du prix au total de nombre de pi�ce
    public void Pay(int price)
    {
        coinsCount -= price;
        UpdateCoinsCount();
    }

    // met � jour l'affichage du nombre de pi�ce
    public void UpdateCoinsCount()
    {
        coinsCountText.text = coinsCount.ToString();
    }
}
