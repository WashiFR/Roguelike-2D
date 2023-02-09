using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numHearths;

    public Image[] hearths;
    public Sprite fullHearth;
    public Sprite halfHearth;
    public Sprite emptyHearth;

    private void Update()
    {
        // empeche d'avoir plus de coeur que prevue
        if (health > numHearths)
        {
            health = numHearths;
        }

        for (int i = 0; i < hearths.Length; i++)
        {
            if (i < health)
            {
                hearths[i].sprite = fullHearth;
            }
            else
            {
                hearths[i].sprite = emptyHearth;
            }

            if (i < numHearths)
            {
                hearths[i].enabled = true;
            }
            else
            {
                hearths[i].enabled = false;
            }
        }
    }
}
