using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float turnDegree = 10;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
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
