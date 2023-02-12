using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // vitesse du joueur
    public float speed;

    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    public Animator animator;

    public Vector3 move;

    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    private void FixedUpdate()
    {
        // dans FixedUpdate pour ne pas avoir de tremblement
        Move();
    }

    // deplacement du joueur
    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical);
        rb.velocity = direction * speed;

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
    }

    // change la direction du regard du joueur
    public void Flip()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        move = new Vector3(x, y, 0);

        if (move.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (move.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
