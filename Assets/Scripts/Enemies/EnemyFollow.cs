using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public CapsuleCollider2D box2D;
    public GameObject healthBar;

    public Animator animator;

    public GameObject player;
    public EnemiesDetect detect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemiesDetect") && box2D.IsTouching(collision))
        {
            detect = collision.GetComponent<EnemiesDetect>();
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Chasing", detect.playerDetected);

        if (detect.playerDetected)
        {
            Flip();
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    // change la direction du regard de l'ennemie
    public void Flip()
    {
        if (transform.position.x - player.transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            healthBar.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x - player.transform.position.x < 0)
        {
            transform.localScale = Vector3.one;
            healthBar.transform.localScale = Vector3.one;
        }
    }
}
