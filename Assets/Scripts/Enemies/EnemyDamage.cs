using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public BoxCollider2D box2D;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && box2D.IsTouching(collision))
        {
            PlayerHealth.instance.TakeDamage(damage);
        }
    }
}
