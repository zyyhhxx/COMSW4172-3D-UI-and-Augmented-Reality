using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to rotate camera and keep the camera at a fixed distance from the player

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float turnDegree = 10;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    public void TurnLeft()
    {
        transform.Rotate(0, turnDegree, 0);
    }

    public void TurnRight()
    {
        transform.Rotate(0, -turnDegree, 0);
    }
}
