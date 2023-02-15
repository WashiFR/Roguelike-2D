using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    public float amount;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer") && PlayerHealth.instance.health < PlayerHealth.instance.maxHearts)
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            PlayerHealth.instance.Heal(amount);
            Destroy(gameObject);
        }
    }
}
