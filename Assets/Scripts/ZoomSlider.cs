using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomSlider : MonoBehaviour
{
    public GameObject toZoom;

    private Vector3 _defScale;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _defScale = toZoom.transform.localScale;
    }

    public void Zoom(float value)
    {
        toZoom.transform.localScale = _defScale * value;
    }
}
