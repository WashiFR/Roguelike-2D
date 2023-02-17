using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;

    public float attackValue;
    public float knockbackForce;

    public SpriteRenderer sprite;

    private void Start()
    {
        sprite.color = new Color(1, 1, 1, 0);
    }
}
