using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public int currentWeapon;
    public Weapon[] weapons;

    public float attackBonus;
    public float attack;
    public float attackValue;

    public float knockbackBonus;
    public float knockback;
    public float knockbackValue;

    public bool isAttacking = false;
    public bool canAttack = true;

    public static PlayerWeapon instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerWeapon dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        CurrentWeaponUpdate();
        UpdateValues();
    }

    public void CurrentWeaponUpdate()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == currentWeapon)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }

        attack = weapons[currentWeapon].attackValue;
        knockback = weapons[currentWeapon].knockbackForce;
    }

    public void ChangeCurrentWeapon(string weaponName)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].weaponName == weaponName)
            {
                weapons[i].gameObject.SetActive(true);
                currentWeapon = i;
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }

        attack = weapons[currentWeapon].attackValue;
        knockback = weapons[currentWeapon].knockbackForce;
        UpdateValues();
    }

    public void UpdateValues()
    {
        attackValue = attack + attackBonus;
        knockbackValue = knockback + knockbackBonus;
    }

    // Update is called once per frame
    void Update()
    {
        Swing();
    }

    // augmente l'attaque du joueur
    public void MoreAttackValue(float amount)
    {
        attackBonus += amount;
        UpdateValues();
    }

    // augmente le recul de l'attaque du joueur
    public void MoreKnockbackValue(float amount)
    {
        knockbackBonus += amount;
        UpdateValues();
    }

    // lance l'animation d'attaque
    public void Swing()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            StartCoroutine(AttackDelay(0.001f));
            weapons[currentWeapon].animator.SetTrigger("Swing");
            StartCoroutine(HideWeapon(0.3f));
            StartCoroutine(AttackDuration(0.2f));
        }
    }

    // permet de pouvoir réattaquer après la fin d'animation d'attaque
    public IEnumerator AttackDuration(float duration)
    {
        canAttack = false;
        yield return new WaitForSeconds(duration);
        canAttack = true;
    }

    // permet de ne pas infliger plusieurs dégâts par frame
    public IEnumerator AttackDelay(float delay)
    {
        isAttacking = true;
        yield return new WaitForSeconds(delay);
        isAttacking = false;
    }

    public IEnumerator HideWeapon(float duration)
    {
        weapons[currentWeapon].sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(duration);
        weapons[currentWeapon].sprite.color = new Color(1, 1, 1, 0);
    }

}
