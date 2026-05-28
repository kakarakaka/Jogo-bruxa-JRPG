using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0, 5, -7);

    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition =
            target.position + target.TransformDirection(offset);
        transform.position = desiredPosition;

        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}