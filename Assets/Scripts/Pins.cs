using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{

    public Transform basis;
    public bool isUp = true;

    [SerializeField, HideInInspector] private Renderer[] arts;

    void Start()
    {
        arts = GetComponents<Renderer>();
    }

    void AllowRender(bool visible)
    {
        foreach (var art in arts)
            art.enabled = visible;
    }

    void Update()
    {
        if (isUp)
            AllowRender(basis.worldToLocalMatrix.MultiplyVector(transform.position).y >= 0);
        else
            AllowRender(basis.worldToLocalMatrix.MultiplyVector(transform.position).y < 0);
    }
}
