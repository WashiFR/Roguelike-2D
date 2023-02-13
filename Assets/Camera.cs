using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Animator animator;

    public static Camera instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de Camera dans la sc�ne");
            return;
        }

        instance = this;
    }

    // effet tramblement de cam�ra
    public void Shake()
    {
        animator.SetTrigger("Shake");
    }
}
