using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector3 newCamPos;
    public Vector3 newPlayerPos;

    public CamController camControl;

    // Start is called before the first frame update
    void Start()
    {
        camControl = GameObject.FindGameObjectWithTag("Camera").GetComponent<CamController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camControl.minPos += newCamPos;
            camControl.maxPos += newCamPos;

            collision.transform.position += newPlayerPos;
        }
    }
}
