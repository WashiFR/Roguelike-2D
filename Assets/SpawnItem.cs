using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject[] potions;        // 50% spawn
    public GameObject[] weapons;        // 30% spawn
    public GameObject[] others;         // 20% spawn
    public int rand, choise;

    void Start()
    {
        rand = Random.Range(0, 10);

        if (rand < 2)
        {
            choise = Random.Range(0, others.Length);
            Instantiate(others[choise], transform.position, Quaternion.identity);
        }
        else if (rand < 5)
        {
            choise = Random.Range(0, weapons.Length);
            Instantiate(weapons[choise], transform.position, Quaternion.identity);
        }
        else
        {
            choise = Random.Range(0, potions.Length);
            Instantiate(potions[choise], transform.position, Quaternion.identity);
        }
    }
}
