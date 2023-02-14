using System.Collections;
using System.Collections.Generic;
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

    public bool isDead = false;
    public bool isInvincible = false;
    public float invincibilityFlashDelay;
    public float invincibilityTimeDelay;

    public SpriteRenderer graphics;

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

    private void Update()
    {
        // test temporaire
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            MoreHeart();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Heal(0.5f);
        }

        // vérifie si le joueur est mort
        if (health <= 0)
        {
            Die();
        }

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
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    // perd des pv/coeurs
    public void TakeDamage(float amount)
    {
        if (!isInvincible)
        {
            health -= amount;
            isInvincible = true;
            Camera.instance.Shake();
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

    // tue le joueur
    public void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
