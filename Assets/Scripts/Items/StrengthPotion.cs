using UnityEngine;

public class StrengthPotion : Items
{
    public float amount;

    // utilise l'objet
    public override void UseItem()
    {
        AudioManager.instance.PlayClipAt(soundEffect, transform.position);
        PlayerCoins.instance.Pay(price);
        PlayerWeapon.instance.MoreAttackValue(amount);
        Destroy(gameObject);
    }
}
