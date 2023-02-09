using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // vitesse du joueur
    public float speed;

    public Rigidbody2D rb;
    public SpriteRenderer sprite;

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
    }

    // change la direction du regard du joueur
    public void Flip()
    {
        if (rb.velocity.x > 0.1f)
        {
            sprite.flipX = false;
        }
        else if (rb.velocity.x < -0.1f)
        {
            sprite.flipX = true;
        }
    }
}
