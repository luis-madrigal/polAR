using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    public Camera cam;

    void Update()
    {
        transform.LookAt(cam.transform, cam.transform.up);
    }
}
