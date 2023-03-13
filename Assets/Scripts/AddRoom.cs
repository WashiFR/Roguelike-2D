using UnityEngine;

public class AddRoom : MonoBehaviour
{
    // This script is attached to the room prefabs
    public RoomTemplates templates;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }
}
