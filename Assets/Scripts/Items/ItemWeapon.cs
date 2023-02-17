using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeapon : Items
{
    public string weaponName;

    public override void UseItem()
    {
        AudioManager.instance.PlayClipAt(soundEffect, transform.position);
        PlayerCoins.instance.Pay(price);
        PlayerWeapon.instance.ChangeCurrentWeapon(weaponName);
        Destroy(gameObject);
    }
}
