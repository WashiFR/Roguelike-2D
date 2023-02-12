using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    public Animator animator;

    public bool isAttacking = false;
    public bool canAttack = true;

    public static PlayerSword instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerSword dans la scène");
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Swing();
    }

    // lance l'animation d'attaque
    public void Swing()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            StartCoroutine(AttackDelay(0.001f));
            animator.SetTrigger("Swing");
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
}
