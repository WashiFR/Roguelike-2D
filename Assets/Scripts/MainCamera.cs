using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Animator animator;

    public static MainCamera instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de MainCamera dans la sc�ne");
            return;
        }

        instance = this;
    }

    // effet tramblement de cam�ra
    public void Shake()
    {
        animator.SetTrigger("Shake");
    }

    public void DoorShake()
    {
        animator.SetTrigger("DoorShake");
    }
}
