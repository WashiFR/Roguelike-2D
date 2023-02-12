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

    // l'ennemie prend des dégâts
    public void TakeDamage()
    {
        if (PlayerSword.instance.isAttacking && !isInvincible)
        {
            health--;
            StartCoroutine(FlashImpact(0.1f));
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

        Destroy(gameObject);
    }
}
