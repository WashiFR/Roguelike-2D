using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public int maxHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public float armor;
    public int maxArmor;

    public Image[] armors;
    public Sprite fullArmor;
    public Sprite halfArmor;

    public bool isDead = false;
    public bool isInvincible = false;
    public float invincibilityFlashDelay;
    public float invincibilityTimeDelay;

    public SpriteRenderer graphics;

    public Animator animator;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    public static PlayerHealth instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        UpdateHearts();

        UpdateArmor();
    }

    private void Update()
    {
        // test temporaire
        /*if (Input.GetKeyDown(KeyCode.F)) TakeDamage(0.5f);
        if (Input.GetKeyDown(KeyCode.T)) TakeDamage(1.5f);
        if (Input.GetKeyDown(KeyCode.A)) MoreArmor();
        if (Input.GetKeyDown(KeyCode.C)) MoreHeart();*/

        Die();

        UpdateHearts();

        UpdateArmor();
    }

    // perd des pv/coeurs
    public void TakeDamage(float amount)
    {
        if (!isInvincible)
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            animator.SetTrigger("Hit");
            if (armor > 0)
            {
                if (armor - amount < 0)
                {
                    float temp = armor;
                    armor = 0;
                    health -= amount - temp;
                }
                else
                {
                    armor -= amount;
                }
            }
            else
            {
                health -= amount;
            }
            isInvincible = true;
            MainCamera.instance.Shake();
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(InvincibilityDelay());
        }
    }

    // animation d'invincibilité
    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    // temps d'invincibilité
    public IEnumerator InvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeDelay);
        isInvincible = false;
    }

    // gagne des pv/coeurs
    public void Heal(float amount)
    {
        health += amount;
    }

    // ajoute 1 coeur maximum
    public void MoreHeart()
    {
        maxHearts++;
        health++;
    }

    // ajoute 1 d'armure
    public void MoreArmor()
    {
        armor++;
    }

    // met à jour le nombre de coeur
    public void UpdateHearts()
    {
        // empeche d'avoir plus de coeur que le nombre max de coeurs définit
        if (health > maxHearts)
        {
            health = maxHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i == health - 0.5f)
            {
                hearts[i].sprite = halfHeart;
            }
            else if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHearts)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    public void UpdateArmor()
    {
        // empeche d'avoir plus d'armue que le nombre max d'armure définit
        if (armor > maxArmor)
        {
            armor = maxArmor;
        }

        for (int i = 0; i < armors.Length; i++)
        {
            if (i == armor - 0.5f)
            {
                armors[i].sprite = halfArmor;
            }
            else if (i < armor)
            {
                armors[i].sprite = fullArmor;
            }
            else
            {
                armors[i].gameObject.SetActive(false);
            }

            if (i < armor)
            {
                armors[i].gameObject.SetActive(true);
            }
            else
            {
                armors[i].gameObject.SetActive(false);
            }
        }
    }

    // tue le joueur
    public void Die()
    {
        if (health <= 0)
        {
            isDead = true;
            gameObject.SetActive(false);
        }
    }

    public void UpdateHealthValues(float health, float maxHearts, float armor, SpriteRenderer graphics, Animator animator)
    {
        this.health = health;
        this.maxHearts = (int)maxHearts;
        this.armor = armor;
        this.graphics = graphics;
        this.animator = animator;
    }
}
