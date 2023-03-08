using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;

    public Vector3 targetPos;
    public Vector3 newPos;

    public Vector3 minPos;
    public Vector3 maxPos;

    private void Update()
    {
        if (transform.position != player.position)
        {
            targetPos = player.position;

            Vector3 camBoundaryPos = new Vector3(
                Mathf.Clamp(targetPos.x, minPos.x, maxPos.x),
                Mathf.Clamp(targetPos.y, minPos.y, maxPos.y),
                Mathf.Clamp(targetPos.z, minPos.z, maxPos.z)
                );

            newPos = Vector3.Lerp(transform.position, camBoundaryPos, smoothSpeed);
            
            transform.position = newPos;
        }
    }
}
