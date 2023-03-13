using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    public int rand;
    public GameObject chest;
    public GameObject mimic;

    // Start is called before the first frame update
    void Start()
    {
        // 0 --> no chest 33%
        // 1 --> chest 66%
        rand = Random.Range(1, 4);

        if (rand <= 2)
        {
            // 5 --> mimic 5%
            // 0..4 --> real chest 95%
            rand = Random.Range(1, 100);

            if (rand <= 5)
            {
                Instantiate(mimic.transform, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(chest.transform, transform.position, Quaternion.identity);
            }
        }
    }
}
