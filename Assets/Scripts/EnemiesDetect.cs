using System.Collections.Generic;
using UnityEngine;

public class EnemiesDetect : MonoBehaviour
{
    public bool doorsClosed;
    public bool playerDetected;
    public bool enemiesDetected;
    public GameObject[] doors;
    public List<GameObject> enemies;
    public int enemiesCount;

    public BoxCollider2D box2DPlayer;
    public BoxCollider2D box2DEnemies;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootEnemy") || collision.CompareTag("FootBoss"))
        {
            if (!playerDetected && !doorsClosed)
            {
                enemies.Add(collision.gameObject);
                enemiesCount = enemies.Count;
            }
            else
            {
                enemiesCount++;
            }
        }
        if (collision.CompareTag("Player"))
        {
            playerDetected = true;
            box2DPlayer.enabled = false;
            box2DEnemies.enabled = true;
        }

        if (playerDetected && enemiesDetected && !doorsClosed)
        {
            audioSource.PlayOneShot(soundEffect);
            MainCamera.instance.DoorShake();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FootEnemy") || collision.CompareTag("FootBoss"))
        {
            enemiesCount--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesCount != 0)
        {
            enemiesDetected = true;
        }
        else
        {
            enemiesDetected = false;
        }

        if (playerDetected && enemiesDetected && !doorsClosed)
        {
            Doors(true);
        }
        else if (!enemiesDetected)
        {
            Doors(false);
        }
    }

    public void Doors(bool isClosed)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].gameObject.SetActive(isClosed);
            doorsClosed = isClosed;
        }
    }
}
