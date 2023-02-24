using UnityEngine;

public class LittleHeart : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerHealth.instance.health < PlayerHealth.instance.maxHearts)
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            PlayerHealth.instance.Heal(0.5f);
            Destroy(gameObject);
        }
    }
}
