using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    public int amount;

    public GameObject player;
    public float speed;
    public CircleCollider2D circleCollider;
    public CapsuleCollider2D capsuleCollider;
    public bool isPlayerDetected;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            if (capsuleCollider.IsTouching(collision))
            {
                AudioManager.instance.PlayClipAt(soundEffect, transform.position);
                Destroy(gameObject);
                PlayerCoins.instance.AddCoin(amount);
            }
            else if (circleCollider.IsTouching(collision))
            {
                isPlayerDetected = true;
            }
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("FootPlayer");
    }

    private void Update()
    {
        if (isPlayerDetected)
        {
            StartCoroutine(MoveToPlayer());
        }
    }

    public IEnumerator MoveToPlayer()
    {
        yield return new WaitForSeconds(2f);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        speed += Time.deltaTime;
    }
}
