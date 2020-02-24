using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to rescale objects

public class Resizing : MonoBehaviour
{
    public float rate = 0.5f;
    public float upperLimit = 2;
    public float lowerLimit = 0.5f;
    private bool grow = true;

    void Update()
    {
        float newScale;
        if (grow)
            newScale = transform.localScale.x + rate * Time.deltaTime;
        else
            newScale = transform.localScale.x - rate * Time.deltaTime;
        if (newScale > upperLimit || newScale < lowerLimit)
            grow = !grow;
        transform.localScale = new Vector3(newScale, transform.localScale.y, transform.localScale.z);
    }
}
