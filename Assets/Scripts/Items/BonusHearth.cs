using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHearth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            PlayerHealth.instance.MoreHearth();
            Destroy(gameObject);
        }
    }
}
