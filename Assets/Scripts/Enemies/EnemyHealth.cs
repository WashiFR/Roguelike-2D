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

    public GameObject reward;

    public RectTransform whiteBar;
    public RectTransform redBar;
    public float fullWidth;

    public float whiteBarDelay;

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

        if (whiteBar.rect.width != redBar.rect.width)
        {
            AnimateHealthBar();
        }

        if (health <= 0)
        {
            Die();
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
            health -= PlayerSword.instance.attackValue;
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
        // animation de mort
        var death = Instantiate(blood, transform.position, transform.rotation);
        death.Play();

        Reward();

        Destroy(gameObject);
    }

    // donne des récompenses
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

    // met à jour la barre de vie
    public void UpdateHealthBar()
    {
        redBar.sizeDelta = new Vector2((health / maxHealth) * fullWidth, redBar.rect.height);
    }

    // animation de la barre de vie
    public void AnimateHealthBar()
    {
        whiteBar.sizeDelta = new Vector2(whiteBarDelay, redBar.rect.height);
        whiteBarDelay--;
    }
}
