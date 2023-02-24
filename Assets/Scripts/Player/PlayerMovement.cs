using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // vitesse du joueur
    public float speed;

    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    public Animator animator;

    public Vector3 move;

    public Camera mainCam;
    public Vector3 mousePos;

    public static PlayerMovement instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

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
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        if (!PauseMenu.instance.isGamePaused)
        {
            if (direction.x < 0)
            {
                sprite.flipX = true;
            }
            else if (direction.x > 0)
            {
                sprite.flipX = false;
            }
        }
    }

    // augmente la vitesse du joueur
    public void MoreSpeedValue(float amount)
    {
        speed += amount;
    }
}
