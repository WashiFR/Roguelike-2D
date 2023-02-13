using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public bool canTakeDamage = false;
    public bool isInvincible = false;

    public ParticleSystem blood;

    public SpriteRenderer sprite;
    public Material originalMaterial;
    public Material whiteMaterial;

    public GameObject reward;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            canTakeDamage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            canTakeDamage = false;
        }
    }

    private void Start()
    {
        originalMaterial = sprite.material;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }

        if (canTakeDamage)
        {
            TakeDamage();
        }
    }

    // l'ennemie prend des d�g�ts
    public void TakeDamage()
    {
        if (PlayerSword.instance.isAttacking && !isInvincible)
        {
            health--;
            StartCoroutine(FlashImpact(0.1f));
            Camera.instance.Shake();
        }
    }

    // animation d'impact
    public IEnumerator FlashImpact(float delay)
    {
        sprite.material = whiteMaterial;
        isInvincible = true;
        yield return new WaitForSeconds(delay);
        sprite.material = originalMaterial;
        isInvincible = false;
    }

    // l'ennemie meurt
    public void Death()
    {
        // animation de mort
        var death = Instantiate(blood, transform.position, transform.rotation);
        death.Play();

        Reward();

        Destroy(gameObject);
    }

    // donne des r�compenses
    public void Reward()
    {
        int numberReward = Random.Range(0, 3);

        for (int i = 0; i < numberReward; i++)
        {
            float randomPosX = Random.Range(-0.5f, 0.5f);
            float randomPosY = Random.Range(-0.5f, 0.5f);

            Vector3 randomPos = new Vector3(randomPosX, randomPosY, 0);

            Instantiate(reward, transform.position + randomPos, transform.rotation);
        }
    }
}
