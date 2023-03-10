using UnityEngine;

public class SpeedPotion : Items
{
    public float amount;

    // utilise l'objet
    public override void UseItem()
    {
        AudioManager.instance.PlayClipAt(soundEffect, transform.position);
        PlayerCoins.instance.Pay(price);
        PlayerMovement.instance.MoreSpeedValue(amount);
        Destroy(gameObject);
    }
}
