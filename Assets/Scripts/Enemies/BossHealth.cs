using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool canTakeDamage = false;
    public bool isInvincible = false;

    public SpriteRenderer sprite;
    public Material originalMaterial;
    public Material whiteMaterial;

    public GameObject[] rewards;

    public Slider healthBar;

    public Rigidbody2D rb;
    public BoxCollider2D box2D;
    public CapsuleCollider2D capsuleCollider;
    public EnemiesDetect detect;

    public AudioSource audioSource;
    public AudioClip soundEffect;
    public AudioClip dieSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && box2D.IsTouching(collision))
        {
            canTakeDamage = true;
        }
        if (collision.CompareTag("EnemiesDetect") && capsuleCollider.IsTouching(collision))
        {
            detect = collision.GetComponent<EnemiesDetect>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !box2D.IsTouching(collision))
        {
            canTakeDamage = false;
        }
    }

    private void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        originalMaterial = sprite.material;
    }

    private void Update()
    {
        DisplayHealthBar();

        Die();

        TakeDamage();
    }

    // l'ennemie prend des dégâts
    public void TakeDamage()
    {
        if (PlayerWeapon.instance.isAttacking && !isInvincible && canTakeDamage)
        {
            health -= PlayerWeapon.instance.attackValue;
            UpdateHealthBar();
            StartCoroutine(FlashImpact(0.1f));
            MainCamera.instance.Shake();

            if (health > 0)
            {
                AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            }
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

            /*Reward();*/

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
        healthBar.value = health;
    }

    // affiche ou non la barre de vie
    public void DisplayHealthBar()
    {
        if (detect.playerDetected || health < maxHealth)
        {
            healthBar.gameObject.SetActive(true);
        }
        else
        {
            healthBar.gameObject.SetActive(false);
        }
    }
}
