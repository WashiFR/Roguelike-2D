using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    public int rand;
    public GameObject chest;
    public GameObject mimic;

    // Start is called before the first frame update
    void Start()
    {
        // 0 --> no chest 50%
        // 1 --> chest 50%
        rand = Random.Range(0, 2);

        if (rand == 1)
        {
            // 5 --> mimic 20%
            // 0..4 --> real chest 80%
            rand = Random.Range(0, 6);

            if (rand == 5)
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
