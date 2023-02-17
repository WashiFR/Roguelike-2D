using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnockbackPotion : Items
{
    public float amount;

    // utilise l'objet
    public override void UseItem()
    {
        AudioManager.instance.PlayClipAt(soundEffect, transform.position);
        PlayerCoins.instance.Pay(price);
        PlayerWeapon.instance.MoreKnockbackValue(amount);
        Destroy(gameObject);
    }
}
