using UnityEngine;

public class ItemWeapon : Items
{
    public string weaponName;

    public override void UseItem()
    {
        if (PlayerWeapon.instance.weapons[PlayerWeapon.instance.currentWeapon].weaponName != weaponName)
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            PlayerCoins.instance.Pay(price);
            PlayerWeapon.instance.ChangeCurrentWeapon(weaponName);
            Destroy(gameObject);
        }
    }
}
