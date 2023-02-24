using UnityEngine;

public class BossFollow : MonoBehaviour
{
    public float speed;
    public CircleCollider2D box2D;

    /*public Animator animator;*/

    public bool isPlayerDetected;
    public GameObject player;
    public EnemiesDetect detect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && box2D.IsTouching(collision))
        {
            isPlayerDetected = true;
            /*if (animator.parameterCount >= 1)
            {
                animator.SetBool("Chasing", isPlayerDetected);
            }*/
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !box2D.IsTouching(collision))
        {
            isPlayerDetected = false;
            /*if (animator.parameterCount >= 1)
            {
                animator.SetBool("Chasing", isPlayerDetected);
            }*/
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDetected && detect.playerDetected)
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
        }
        else if (transform.position.x - player.transform.position.x < 0)
        {
            transform.localScale = Vector3.one;
        }
    }
}
