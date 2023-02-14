using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool canTakeDamage = false;
    public bool isInvincible = false;

    public ParticleSystem blood;

    public SpriteRenderer sprite;
    public Material originalMaterial;
    public Material whiteMaterial;

    public GameObject[] rewards;

    public GameObject healthBar;
    public RectTransform whiteBar;
    public RectTransform redBar;
    public float fullWidth;

    public float whiteBarDelay;

    public float knockbackForce;
    public float knockbackDuration;
    public Rigidbody2D rb;

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
        fullWidth = whiteBar.rect.width;
        whiteBarDelay = fullWidth;
    }

    private void Update()
    {
        UpdateHealthBar();

        DisplayHealthBar();

        AnimateHealthBar();

        Die();

        TakeDamage();
    }

    // l'ennemie prend des dégâts
    public void TakeDamage()
    {
        if (PlayerSword.instance.isAttacking && !isInvincible && canTakeDamage)
        {
            health -= PlayerSword.instance.attackValue;
            TakeKnockback(rb.position, knockbackForce);
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
    public void Die()
    {
        if (health <= 0)
        {
            // animation particule de mort
            var death = Instantiate(blood, transform.position, transform.rotation);
            death.Play();

            Reward();

            Destroy(gameObject);
        }
    }

    // donne des récompenses
    public void Reward()
    {
        int numberOfReward = Random.Range(0, 2);
        int objectReward = Random.Range(0, rewards.Length);

        // pièces
        if (rewards[objectReward].name == "Coin")
        {
            numberOfReward = Random.Range(0, 4);
        }

        for (int i = 0; i < numberOfReward; i++)
        {
            float randomPosX = Random.Range(-0.5f, 0.5f);
            float randomPosY = Random.Range(-0.5f, 0.5f);

            Vector3 randomPos = new Vector3(randomPosX, randomPosY, 0);

            Instantiate(rewards[objectReward], transform.position + randomPos, transform.rotation);
        }

        Debug.Log("Récompense : " + rewards[objectReward].name + " x " + numberOfReward);
    }

    // met à jour la barre de vie
    public void UpdateHealthBar()
    {
        redBar.sizeDelta = new Vector2((health / maxHealth) * fullWidth, redBar.rect.height);
    }

    // animation de la barre de vie
    public void AnimateHealthBar()
    {
        if (whiteBar.rect.width != redBar.rect.width)
        {
            whiteBar.sizeDelta = new Vector2(whiteBarDelay, redBar.rect.height);
            whiteBarDelay--;
        }
    }

    // affiche ou non la barre de vie
    public void DisplayHealthBar()
    {
        if (health == maxHealth)
        {
            healthBar.SetActive(false);
        }
        else
        {
            healthBar.SetActive(true);
        }
    }

    public void TakeKnockback(Vector3 direction, float force)
    {
        // applique une force dans la direction de l'impact
        rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);

        // limite la magnitude de la force
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, knockbackForce);
        StartCoroutine(StopKnockback());
    }

    private IEnumerator StopKnockback()
    {
        // attend la fin du knockback
        yield return new WaitForSeconds(knockbackDuration);

        // réduit progressivement la vitesse de l'objet jusqu'à ce qu'elle atteigne zéro
        while (rb.velocity != Vector2.zero)
        {
            rb.velocity = Vector2.MoveTowards(rb.velocity, Vector2.zero, knockbackForce * Time.deltaTime);
            yield return null;
        }
    }
}