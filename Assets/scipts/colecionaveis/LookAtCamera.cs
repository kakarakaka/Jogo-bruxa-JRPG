using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        if (cam == null) return;

        Vector3 target = cam.transform.position;
        target.y = transform.position.y;

        transform.LookAt(target);
    }
}