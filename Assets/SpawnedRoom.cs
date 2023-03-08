using UnityEngine;

public class SpawnedRoom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnedRoom"))
        {
            Debug.Log("Delete");
            Destroy(gameObject);
        }
    }
}
