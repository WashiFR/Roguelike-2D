using UnityEngine;

public class HealPotion : Items
{
    public float amount;

    // utilise l'objet
    public override void UseItem()
    {
        if (PlayerHealth.instance.health < PlayerHealth.instance.maxHearts)
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            PlayerCoins.instance.Pay(price);
            PlayerHealth.instance.Heal(amount);
            Destroy(gameObject);
        }
    }
}
