using UnityEngine;

public class HideRoom : MonoBehaviour
{
    public GameObject room;
    public EnemiesDetect detection;

    public GameObject darkCloud;

    void Start()
    {
        room = transform.parent.gameObject;
        detection = room.GetComponentInChildren<EnemiesDetect>();
    }

    private void Update()
    {
        if (detection.playerDetected)
        {
            darkCloud.SetActive(false);
        }
    }
}
