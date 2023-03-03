using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    public BoxCollider2D boxCollider2;
    public int random;
    public int enemiesCount;
    public int haveEnemies;
    // 0 : have enemies
    // 1 : don't have enemies

    void Start()
    {
        haveEnemies = Random.Range(0, 1);

        if (haveEnemies == 0)
        {
            enemiesCount = Random.Range(0, 5);

            for (int i = 0; i < enemiesCount; i++)
            {
                Vector2 randomPos = new Vector2(
                    Mathf.Round(Random.Range(boxCollider2.bounds.min.x, boxCollider2.bounds.max.x)),
                    Mathf.Round(Random.Range(boxCollider2.bounds.min.y, boxCollider2.bounds.max.y))
                    );

                random = Random.Range(0, enemies.Length);

                Instantiate(enemies[random], randomPos, Quaternion.identity);
            }
        }
    }
}
