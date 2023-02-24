using UnityEngine;

public class Coin : MonoBehaviour
{
    public int amount;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            Destroy(gameObject);
            PlayerCoins.instance.AddCoin(amount);
        }
    }
}
