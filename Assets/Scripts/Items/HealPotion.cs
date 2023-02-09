using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    public float amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer") && PlayerHealth.instance.health < PlayerHealth.instance.maxHearths)
        {
            PlayerHealth.instance.Heal(amount);
            Destroy(gameObject);
        }
    }
}
