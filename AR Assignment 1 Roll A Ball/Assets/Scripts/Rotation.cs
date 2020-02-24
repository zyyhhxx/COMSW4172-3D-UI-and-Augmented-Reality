using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the class to rotate objects

public class Rotation : MonoBehaviour
{
    public bool speedX;
    public bool speedY;
    public bool speedZ;
    public float speed;
    public float maxSpeed;
    public float minSpeed;

    // Update is called once per frame
    void Update()
    {
        if (speedX)
        {
            transform.Rotate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }
        else if (speedY)
        {
            transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime);
        }
        else if (speedZ)
        {
            transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
        }
    }
}
