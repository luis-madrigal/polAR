using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate : MonoBehaviour, IDragHandler
{

    public Camera cam;
    public float rotSpeed = 20;
    public void OnDrag(PointerEventData e)
    {
        float rotX = e.delta.x * rotSpeed * Mathf.Deg2Rad;
        float rotY = e.delta.y * rotSpeed * Mathf.Deg2Rad;

        transform.Rotate(cam.transform.up, -rotX, Space.World);
        transform.Rotate(cam.transform.right, rotY, Space.World);
    }
}