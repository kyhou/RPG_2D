using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private BoxCollider2D bounds;
    private CameraController camController;

    void Start()
    {
        bounds = GetComponent<BoxCollider2D>();
        camController = FindObjectOfType<CameraController>();
        camController.SetBounds(bounds);
    }
}