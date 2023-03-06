using UnityEngine;

public class BonusArmor : Items
{
    // utilise l'objet
    public override void UseItem()
    {
        AudioManager.instance.PlayClipAt(soundEffect, transform.position);
        PlayerCoins.instance.Pay(price);
        PlayerHealth.instance.MoreArmor();
        Destroy(gameObject);
    }
}
