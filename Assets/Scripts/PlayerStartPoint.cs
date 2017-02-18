using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private PlayerController playerController;
    private CameraController cameraController;

    public Vector2 startDirection;
    public string pointName;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        if (playerController.startPoint == pointName)
        {
            playerController.transform.position = transform.position;
            playerController.lastMove = startDirection;

            cameraController = FindObjectOfType<CameraController>();
            cameraController.transform.position = new Vector3(transform.position.x, transform.position.y, cameraController.transform.position.z);
        }
    }

    void Update()
    {

    }
}