using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;

    public bool spawnedBoss;
    public GameObject boss;

    public bool spawnedShop;
    public GameObject shop;

    private void Update()
    {
        if (waitTime <= 0)
        {
            if (!spawnedBoss)
            {
                Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
                spawnedBoss = true;
            }
            if (!spawnedShop)
            {
                int rand = Random.Range(0, rooms.Count - 2);
                Instantiate(shop, rooms[rand].transform.position, Quaternion.identity);
                spawnedShop = true;
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
