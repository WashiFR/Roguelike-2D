using System.Collections;
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
    public GameObject skullHead;

    public GameObject healthBar;
    public RectTransform whiteBar;
    public RectTransform redBar;
    public float fullWidth;

    public float whiteBarDelay;

    public Vector2 difference;
    public bool canTakeKnockback;
    public float knockbackDuration;
    public Rigidbody2D rb;
    public BoxCollider2D box2D;

    public AudioSource audioSource;
    public AudioClip soundEffect;
    public AudioClip dieSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && box2D.IsTouching(collision))
        {
            canTakeDamage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !box2D.IsTouching(collision))
        {
            canTakeDamage = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        difference = (transform.position - collision.transform.position).normalized;
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
        if (PlayerWeapon.instance.isAttacking && !isInvincible && canTakeDamage)
        {
            health -= PlayerWeapon.instance.attackValue;
            StartCoroutine(FlashImpact(0.1f));
            MainCamera.instance.Shake();

            if (health > 0)
            {
                AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            }

            TakeKnockback();
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
            AudioManager.instance.PlayClipAt(dieSoundEffect, transform.position);
            // animation particule de mort
            var death = Instantiate(blood, transform.position, transform.rotation);
            death.Play();

            Reward();

            Instantiate(skullHead, transform.position, Quaternion.identity);

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
    }

    // met à jour la barre de vie
    public void UpdateHealthBar()
    {
        redBar.sizeDelta = new Vector2((health / maxHealth) * fullWidth, redBar.rect.height);
    }

    // animation de la barre de vie
    public void AnimateHealthBar()
    {
        if (whiteBar.rect.width > redBar.rect.width)
        {
            whiteBar.sizeDelta = new Vector2(whiteBarDelay, redBar.rect.height);
            whiteBarDelay -= Time.deltaTime * 100;
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

    // prend du recul
    public void TakeKnockback()
    {
        if (canTakeKnockback)
        {
            rb.AddForce(difference * PlayerWeapon.instance.knockbackValue * rb.mass, ForceMode2D.Impulse);
            StartCoroutine(KnockbackDuration());
        }
    }

    // durée du recul
    public IEnumerator KnockbackDuration()
    {
        yield return new WaitForSeconds(knockbackDuration);
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        yield return new WaitForSeconds(0.01f);
        rb.isKinematic = false;
    }
}