using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHearth : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            PlayerHealth.instance.MoreHeart();
            Destroy(gameObject);
        }
    }
}
