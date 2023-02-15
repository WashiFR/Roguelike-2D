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

    public AudioSource audioSource;
    public AudioClip soundEffect;

    public static PlayerHealth instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerHealth dans la sc�ne");
            return;
        }

        instance = this;
    }

    private void Update()
    {
        Die();

        UpdateHearts();
    }

    // perd des pv/coeurs
    public void TakeDamage(float amount)
    {
        if (!isInvincible)
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            health -= amount;
            isInvincible = true;
            Camera.instance.Shake();
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(InvincibilityDelay());
        }
    }

    // animation d'invincibilit�
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

    // temps d'invincibilit�
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

    // met � jour le nombre de coeur
    public void UpdateHearts()
    {
        // empeche d'avoir plus de coeur que le nombre max de coeurs d�finit
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

    // tue le joueur
    public void Die()
    {
        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }
}
