using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusHearth : Items
{
    // utilise l'objet
    public override void UseItem()
    {
        AudioManager.instance.PlayClipAt(soundEffect, transform.position);
        PlayerCoins.instance.Pay(price);
        PlayerHealth.instance.MoreHeart();
        Destroy(gameObject);
    }
}
