using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public int maxHearths;

    public Image[] hearths;
    public Sprite fullHearth;
    public Sprite halfHearth;
    public Sprite emptyHearth;

    public bool isDead;

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
            Debug.Log("Le joueur a subis des dégats");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            MoreHearth();
            Debug.Log("Le joueur a 1 coeurs permanent supplémentaire");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Heal(0.5f);
            Debug.Log("Le joueur a gagné de la vie");
        }

        // vérifie si le joueur est mort
        if (health == 0)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }

        // empeche d'avoir plus de coeur que le nombre max de coeurs définit
        if (health > maxHearths)
        {
            health = maxHearths;
        }

        for (int i = 0; i < hearths.Length; i++)
        {
            if (i == health - 0.5f)
            {
                hearths[i].sprite = halfHearth;
            }
            else if (i < health)
            {
                hearths[i].sprite = fullHearth;
            }
            else
            {
                hearths[i].sprite = emptyHearth;
            }

            if (i < maxHearths)
            {
                hearths[i].enabled = true;
            }
            else
            {
                hearths[i].enabled = false;
            }
        }
    }

    // perd des pv/coeurs
    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    // gagne des pv/coeurs
    public void Heal(float amount)
    {
        health += amount;
    }

    // ajoute 1 coeur maximum
    public void MoreHearth()
    {
        maxHearths++;
    }
}
